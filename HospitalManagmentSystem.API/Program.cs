
using HospitalManagmentSystem.API.Middleware;
using HospitalManagmentSystem.BLL.AutoMapper;
using HospitalManagmentSystem.BLL.Manager;
using HospitalManagmentSystem.BLL.Manager.Accounts;
using HospitalManagmentSystem.DAL.Data.DbHelper;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Reposatories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HospitalManagmentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Registers
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IAccountManager, AccountManager>();
            builder.Services.AddScoped<IDoctorRepo,DoctorRepo>();
            builder.Services.AddScoped<IPatiebtRepo, PatientRepo>();
            builder.Services.AddScoped<IIssueRepo, IssueRepo>();
            builder.Services.AddScoped<IDoctorManager,DoctorManager>();
            //builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));
            // builder.Services.AddScoped<IDoctorManager, DoctorAutoMapperManger>();
            
            builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequiredLength = 5;

            }).AddEntityFrameworkStores<HospitalSystemContext>();

            //builder.Services.AddIdentity < ApplicationUser,IdentityRole>()
             //   .AddEntityFrameworkStores<HospitalSystemContext>();

            builder.Services.AddAuthentication(Options =>
              {
                Options.DefaultAuthenticateScheme = "JWT"; //Validate on token
                Options.DefaultChallengeScheme = "JWT"; //redirect on login again if not Autantkated
              }).AddJwtBearer("JWT", Options =>
              {
                  var SecretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                  var SecretKeyByte = Encoding.ASCII.GetBytes(SecretKeyString);
                  SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);
                  Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      IssuerSigningKey = securityKey,
                      ValidateIssuer = false, // who Resive token
                      ValidateAudience = false,//FRONTEND who send token
                  };
              });

            builder.Services.AddDbContext<HospitalSystemContext>(options =>
              {
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
              });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); 

            app.UseMiddleware<LoggingMiddelware>(); 
            app.UseMiddleware<Request_Modification_Middelware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
