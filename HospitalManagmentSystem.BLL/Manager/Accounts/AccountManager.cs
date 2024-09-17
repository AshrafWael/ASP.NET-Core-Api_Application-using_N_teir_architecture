using HospitalManagmentSystem.BLL.Dtos.AccountDtos;
using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace HospitalManagmentSystem.BLL.Manager.Accounts
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountManager(UserManager<ApplicationUser> userManager ,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<GenralResponse> Login(AccountLoginDto LoginDto)
        {
            GenralResponse genralResponse = new GenralResponse();
            var user =await _userManager.FindByNameAsync(LoginDto.UserName);
            if (user == null)
            {
                return null;
            }
            else
            {
               var result = await _userManager.CheckPasswordAsync(user,LoginDto.Password);
                if (result == true) 
                {
                    //genrate Token
                    var claims= await _userManager.GetClaimsAsync(user);
                    genralResponse = GenrateToken(claims);
                }
                return genralResponse;
            }
        }
        public async Task<GenralResponse> Register(AccountRegisterDto registerDto)
        {
            //objects
            GenralResponse genralResponse = new GenralResponse();
            ApplicationUser user = new ApplicationUser();
            //mapping form dto to appuser
            user.Email = registerDto.Email;
            user.UserName = registerDto.UserName;
            user.Address = "Cairo";
            //send user and pss
           IdentityResult result = await _userManager.CreateAsync(user,registerDto.Password); //save over Db
            if (result.Succeeded == false)
            {
                return null;
            }
                //create cakims on db
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claims.Add(new Claim("Name", registerDto.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                //add claims on db

                await _userManager.AddClaimsAsync(user, claims);
                genralResponse =GenrateToken(claims);
            return genralResponse;
        }
            private GenralResponse GenrateToken(IList<Claim> claims)
            {

                //Genrate sECRETkEY
                var SecretKeyString = _configuration.GetSection("SecretKey").Value;
                var SecretKeyByte = Encoding.ASCII.GetBytes(SecretKeyString);
                SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);
                //Genrate Signning Credintial comain secret key with Hashing Algorithm
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                // Genrate JwtSecurityToken
                var ExpireDate = DateTime.Now.AddDays(3);
                JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: ExpireDate
                    );
                //Convert To String
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                string token = handler.WriteToken(jwtSecurity);
                return new GenralResponse
                { 
                     Token = token,
                    ExpirationDate = ExpireDate
                
                };
            }
    }
}
