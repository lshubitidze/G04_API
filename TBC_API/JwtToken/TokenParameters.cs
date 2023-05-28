using Fasade.Interfaces.JwtToken;

namespace TBC_API.JwtToken
{
    public class TokenParameters : ITokenParameters
    {
        public TokenParameters()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ValidIssuer = configuration.GetValue<string>("JwtSettings:ValidIssuer");
            ValidAudience = configuration.GetValue<string>("JwtSettings:ValidAudience");
            Key = configuration.GetValue<string>("JwtSettings:Key");
            ExpirationMinutes = configuration.GetValue<int>("JwtSettings:ExpiresInMinutes");
        }
        public string ValidIssuer { get; private set; }
        public string ValidAudience { get; private set; }
        public string Key { get; private set; }
        public int ExpirationMinutes { get; private set; }
    }
}
