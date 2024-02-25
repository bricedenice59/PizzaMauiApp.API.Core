using System.Security.Claims;
using PizzaMauiApp.API.Core.Models;

namespace PizzaMauiApp.API.Core.Services;

public interface ITokenService
{
    /// <summary>
    /// Create a token for a user </summary>
    /// <param name="user">The user we want to create a token to</param>
    /// <param name="forTestingPurpose">if the token is requested for testing</param>
    /// <param name="expirationDelayForTestingPurpose">The default expiration delay of a token if generated for testing</param>
    /// <returns>A valid token for a tokenUser</returns>
    string CreateToken(TokenUser user, bool forTestingPurpose = false, int expirationDelayForTestingPurpose = 600);

    string GenerateRefreshToken();
    
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);

    TokenUser? ValidateToken(string token);
}