using InternProject.Application.Dto;
using InternProject.Domain.Entities;

namespace InternProject.Application.Interfaces;

public interface IAuthenticationService
{
    TokenResponseDto CreateAccessToken (AppUser appuser);
    
    TokenResponseDto CreateAccessTokenByRefreshToken (string refreshToken);

    TokenResponseDto RevokeRefreshToken(string refreshToken);

}