using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TBC_API.JwtToken
{
    public static class JwtConfiguration
    {
        public static TokenValidationParameters SetOptions()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //return new JwtBearerOptions()
            //{
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ClockSkew = TimeSpan.Zero,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = configuration.GetValue<string>("JwtSettings:ValidIssuer"),
            //        ValidAudience = configuration.GetValue<string>("JwtSettings:ValidAudience"),
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //        Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:Key"))),
            //    }
            //};

            return new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetValue<string>("JwtSettings:ValidIssuer"),
                ValidAudience = configuration.GetValue<string>("JwtSettings:ValidAudience"),
                IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:Key"))),
            };
        }
    }
}
