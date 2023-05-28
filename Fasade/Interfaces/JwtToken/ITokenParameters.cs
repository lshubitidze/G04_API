namespace Fasade.Interfaces.JwtToken
{
    public interface ITokenParameters
    {
        string ValidIssuer { get; }
        string ValidAudience { get; }
        string Key { get; }
        int ExpirationMinutes { get; }

    }
}
