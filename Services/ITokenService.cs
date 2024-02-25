using System.Security.Claims;
using PizzaMauiApp.API.Dtos;

namespace PizzaMauiApp.API.Core.Services;

public interface ITokenService
{
    /// <summary>
    /// Create a token for user </summary>
    /// <param name="user">The user we want to create a token to</param>
    /// <param name="forTestingPurpose">if the token is requested for testing</param>
    /// <param name="expirationDelayForTestingPurpose">The default expiration delay of a token if generated for testing</param>
    /// <returns>A valid token for a user</returns>
    string CreateToken(UserDto user, bool forTestingPurpose = false, int expirationDelayForTestingPurpose = 600);

    string GenerateRefreshToken();
    
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);

    UserDto? ValidateToken(string token);
}