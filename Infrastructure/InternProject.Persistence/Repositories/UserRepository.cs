using System.Net;
using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using InternProject.Persistence.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InternProject.Persistence.Repositories;

public class UserRepository : UserManager<AppUser>, IUserRepository
{
    private readonly UserManager<AppUser> _appUser;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;

    public UserRepository(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators, IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger, UserManager<AppUser> appUser, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, RoleManager<AppRole> roleManager) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _appUser = appUser;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _roleManager = roleManager;

       //var asd= _roleManager.FindByNameAsync("admin");
      // _roleManager.CreateAsync()
        
       // _appUser.AddToRoleAsync(user, "admin");
    }

    public async Task<UserResponseDto> AddUser(UserCreateRequestDto request)
    {
        var isEmailUnique = await _appUser.FindByEmailAsync(request.Email) == null;

        if (!isEmailUnique)
            return new UserResponseDto();

        var user = new AppUser()
        {
            Email = request.Email,
            UserName = request.Email,
            ManagerId = request.ManagerId,
            
        };
        
        
        
        var result = await _appUser.CreateAsync(user, request.Password);
        await _appUser.AddToRoleAsync(user, "User");
        
        return result.Succeeded ?
           new UserResponseDto()
           {
               Id = user.Id,
               Email = user.Email,
               UserName = user.Email,
               ManagerId = request.ManagerId
           }:
        new UserResponseDto();
        
    }

    public async Task UpdateUser(UserResponseDto userResponseDto)
    {
        
        var user = await _appUser.FindByIdAsync(userResponseDto.Id.ToString());

        if ( !string.IsNullOrWhiteSpace(userResponseDto.Email))
        {
            if (user.Email != userResponseDto.Email)
            { 
                var isEmailUnique = await _appUser.FindByEmailAsync(userResponseDto.Email) == null;
                    if (isEmailUnique)
                        user.Email = userResponseDto.Email;
            }
               
        }
     
        if ( !string.IsNullOrWhiteSpace(userResponseDto.UserName))
        {
            user.UserName = userResponseDto.UserName;
        }
        
        if ( userResponseDto.ManagerId != 0 )
        {
            user.ManagerId = userResponseDto.ManagerId;
        }
        
        await _appUser.UpdateAsync(user);




    }

    public async Task DeleteUser(int id)
    {
        var user = await _appUser.FindByIdAsync(id.ToString());
        if (user != null)
        {
            user.IsDeleted = true;
            await _appUser.UpdateAsync(user);

        }
        

    }

    public async Task<AccessToken> Login(UserLoginDto dto)
    {
        var user = await _appUser.FindByEmailAsync(dto.Email);
        if (user == null)
            return new AccessToken();
        
        var loginResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
        if (!loginResult.Succeeded)
            return new AccessToken();

        return _tokenHandler.CreateAccessToken(user);
    }

    public async Task<AppUser> FindByEmailAndPassword(AppUser request)
    {
        
        var user = await _appUser.FindByEmailAsync(request.Email);
        if (user == null)
            return new AppUser();
        
        var loginResult = await _signInManager.PasswordSignInAsync(request.Email, request.PasswordHash, false, false);
        if (!loginResult.Succeeded)
            return new AppUser();

        return request;
        
    }
}