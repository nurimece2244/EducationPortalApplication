

using InternProject.Application.Dto;
using InternProject.Domain.Entities;

namespace InternProject.Application.Interfaces;

public interface ITokenHandler
{
    AccessToken CreateAccessToken(AppUser appuser);

    Task RevokeRefreshToken(AppUser appuser);
}