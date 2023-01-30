using InternProject.Application.Dto;
using InternProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace InternProject.Application.Interfaces;
public interface IUserRepository
{
    Task<UserResponseDto> AddUser (UserCreateRequestDto request);
    Task<AccessToken> Login  (UserLoginDto userCreateRequestDto);
    Task UpdateUser (UserResponseDto userResponseDto );
    Task  DeleteUser (int id);
    Task <AppUser> FindByEmailAndPassword(AppUser request);
}