using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
using Superubezpieczenia.MailSender;
using Superubezpieczenia.MailSender.Setings;
using Superubezpieczenia.Persistence.Context;
using Superubezpieczenia.Persistence.Repositories;
using Superubezpieczenia.Services;

namespace Superubezpieczenia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           /* var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "admin";
            var password = Configuration["DBPassword"] ?? "Admin123";
            var database = Configuration["Database"] ?? "Superubezpieczenia";

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID {user};Password={password}"));*/

            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = "ASP.NET Core 3.1 Web API"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                /* options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = false,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])) //Configuration["JwtToken:SecretKey"]  
                 };*/
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            /* services.AddSwaggerGen(options =>
             {
                 options.SwaggerDoc("v1",
                     new Microsoft.OpenApi.Models.OpenApiInfo
                     {
                         Title = "Superubezpieczenia API",
                         Description = "Swagger Superubezpieczenia API",
                         Version = "v1"
                     }) ;
             });*/
            services.AddDbContext<ApplicationDbContext>(options => {
             options.UseSqlServer(Configuration.GetConnectionString("SuperubezpieczeniaDbContext"));
             });
           /* string mySqlConnectionStr = Configuration.GetConnectionString("SuperubezpieczeniaDbContext");
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnectionStr));*/

            // For Identity  
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            // Adding Jwt Bearer  
           /*.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });*/
            services.Configure<MailConfig>(Configuration.GetSection("Mail"));
            services.AddSingleton<IMailService, MailService>();

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IPolicyDetailsService, PolicyDetailsService>();
            services.AddScoped<IPolicyDetailsRepository, PolicyDetailsRepository>();

            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IMarkRepository, MarkRepository>();

            services.AddScoped<ITypeOwnerService, TypeOwnerService>();
            services.AddScoped<ITypeOwnerRepository, TypeOwnerRepository>();

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();

            services.AddScoped<IMethodUseService, MethodUseService>();
            services.AddScoped<IMethodUseRepository, MethodUseRepository>();

            services.AddScoped<IEnginePowerService, EnginePowerService>();
            services.AddScoped<IEnginePowerRepository, EnginePowerRepository>();

            services.AddScoped<IParkingPlaceService, ParkingPlaceService>();
            services.AddScoped<IParkingPlaceRepository, ParkingPalceRepository>();

            services.AddScoped<ITypeInsuranceService, TypeInsuranceService>();
            services.AddScoped<ITypeInsuranceRepository, TypeInsuranceRepository>();

            services.AddScoped<ITypeFuelService, TypeFuelService>();
            services.AddScoped<ITypeFuelRepository, TypeFuelRepository>();

            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<ICalculatorRepository, CalculatorRepository>();

            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();

            services.AddScoped<IUserInsuranceService, UserInsuranceService>();
            services.AddScoped<IUserInsuranceRepository, UserInsuranceRepository>();

            services.AddAutoMapper(typeof(ModelToResourceProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Superubezpieczenia API");
            });
        }
    }
}
