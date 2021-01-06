using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Logger;
using Superubezpieczenia.MailSender;
using Superubezpieczenia.MailSender.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly ILog _log;

        public AuthenticateController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMailService mailService, ILog log)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _mailService = mailService;
            _log = log;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
               

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userRoles,

                }); 
            }
            _log.Save(model.Username, "Użytkownik zalogował się", GetType().Name);
            return Unauthorized();
        }
        


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Użytkownik już istnieje!" });

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Nie udało się stworzyć użytkownika! Proszę sprawdzić poprawność danych i spróbować ponownie." });
            }

            var message = new MailRequest(model.Email, "Rejestracja w Superubeczpieczenia", "Gratuluję udało Ci sie utworzyc konto");
            await _mailService.SendEmail(message);
            _log.Save(model.Username, "Użytkownik został stworzony", GetType().Name);
            return Ok(new Response { Status = "Success", Message = "Użytkownik został stworzony!" });
        }



        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Użytkownik już istnieje!" });

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Nie udało się stworzyć użytkownika! Proszę sprawdzić poprawność danych i spróbować ponownie." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.Agent))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Agent));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            var message = new MailRequest(model.Email, "Rejestrcja w Superubeczpieczenia", "Gratuluję udało Ci sie utworzyc konto");
            await _mailService.SendEmail(message);
            _log.Save(model.Username, "Administrator został stworzony", GetType().Name);
            return Ok(new Response { Status = "Success", Message = "Użytkownik został stworzony!" });
        }




        [HttpPost]
        [Route("register-agent")]
        public async Task<IActionResult> RegisterAgent([FromBody]  RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Użytkownik już istnieje!" });

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Nie udało się stworzyć użytkownika! Proszę sprawdzić poprawność danych i spróbować ponownie." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Agent))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Agent));
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Agent))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Agent);
            }

            var message = new MailRequest(model.Email, "Rejestracja w Superubeczpieczenia", "Gratuluję udało Ci sie utworzyc konto");
            await _mailService.SendEmail(message);
            _log.Save(model.Username, "Konsultant został stworzony", GetType().Name);
            return Ok(new Response { Status = "Success", Message = "Użytkownik został stworzony!" });
        }
    }
}
