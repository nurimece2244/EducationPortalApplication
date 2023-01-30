using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using InternProject.Persistence.Services.Token;

namespace InternProject.Application.Dto;

public class AuthenticationService: IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    private readonly ITokenHandler _tokenHandler;

    public AuthenticationService( IUserRepository _userRepository, ITokenHandler _tokenHandler)
    {
        this._tokenHandler = _tokenHandler;
        this._userRepository = _userRepository;
    }

    public TokenResponseDto CreateAccessToken(AppUser appuser)
    {
        AccessToken accessToken = _tokenHandler.CreateAccessToken(appuser);
            return new TokenResponseDto(accessToken);
       
    }
    
    public TokenResponseDto CreateAccessTokenByRefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public TokenResponseDto RevokeRefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }
}