namespace PizzaMauiApp.API.Core.Environment;

public class TokenAuth0Config
{
    public string? Issuer { get; set; }
    public string? Secret { get; set; }
    public int TokenExpirationDelay { get; set; }
    public int RefreshTokenValidityInDays { get; set; }

    public TokenAuth0Config()
    {
        
    }
}