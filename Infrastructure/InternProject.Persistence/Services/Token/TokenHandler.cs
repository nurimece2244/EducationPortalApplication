using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InternProject.Persistence.Services.Token;

public class TokenHandler: ITokenHandler
{
    private readonly TokenOptions _tokenOptions;
    private readonly UserManager< AppUser> _userManager;

    public TokenHandler( IOptions< TokenOptions> tokenOptions, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        this._tokenOptions = tokenOptions.Value;
    }

    public TokenHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        throw new NotImplementedException();
    }

    public AccessToken CreateAccessToken(AppUser appuser)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        var securityKey = SignHandler.GetSecurityKey(_tokenOptions.SecurityKey );

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims:GetClaim(appuser),
            signingCredentials: signingCredentials

        );

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);
        
        AccessToken accessToken = new AccessToken();

        accessToken.Token = token;
        accessToken.RefreshToken = CreateRefreshToken();
        accessToken.Expiration = accessTokenExpiration;

        return accessToken;
    }
    private  IEnumerable<Claim> GetClaim(AppUser appuser)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, appuser.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, appuser.Email),
            new Claim(ClaimTypes.Name, $"{appuser.UserName}"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var userRoles = _userManager.GetRolesAsync(appuser);
        claims.AddRange(userRoles.Result.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
        return claims;
    }
    //  appuser.Refre  
    public async Task RevokeRefreshToken(AppUser appuser)
    {
      
    }
    private string CreateRefreshToken()
    {
        var numberByte = new Byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
        
        // return Guid.NewGuid().toString();
    }

   
}