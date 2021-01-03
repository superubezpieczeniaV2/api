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
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
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
            var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "admin";
            var password = Configuration["DBPassword"] ?? "Admin123";
            var database = Configuration["Database"] ?? "Superubezpieczenia";

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID {user};Password={password}"));
           

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Superubezpieczenia API",
                        Description = "Swagger Superubezpieczenia API",
                        Version = "v1"
                    }) ;
            });
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SuperubezpieczeniaDbContext"));
            });
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
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
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
            });
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
