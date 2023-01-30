using InternProject.Application.Dto.RoleDto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace InternProject.Persistence.Repositories;

public class RoleServiceRepository : IRoleService
{ 
    private readonly RoleManager<AppRole> _roleManager; 
    private readonly IGenericRepository<AppRole> _genericRepository;
    private readonly UserManager<AppUser> _appUser;
    
    public RoleServiceRepository(RoleManager<AppRole> roleManager, IGenericRepository<AppRole> genericRepository, UserManager<AppUser> appUser)
    {
        _roleManager = roleManager;
        _genericRepository = genericRepository;
        _appUser = appUser;
    }

    public async Task AddRole(RequestAddRoleDto requestAddRoleDto)
    {
      //  var role = await _roleManager.CreateAsync(new AppRole());

        await _genericRepository.AddAsync(new AppRole()
        {
            Name = requestAddRoleDto.Name,
            NormalizedName = _roleManager.NormalizeKey(requestAddRoleDto.Name)
        });


    }

    public async Task UpdateRole(RequestUpdateRoleDto requestUpdateRoleDto)
    {
        var role = await _genericRepository.GetByIdAsync(requestUpdateRoleDto.id);

        if (role != null)
        {
            role.Name = requestUpdateRoleDto.Name;
            role.NormalizedName = _roleManager.NormalizeKey(requestUpdateRoleDto.Name);
            await _genericRepository.Update(role);
        }
          
       

    }

    public async Task DeleteRole(int id)
    {
        var role = await _genericRepository.GetByIdAsync(id);
        if (role != null)
        {
            role.IsDeleted = true;
            await _genericRepository.Update (role); 
        }
          

    }

    public async Task UpdateUserRole(RequestUpdateUserRoleDto requestUpdateUserRoleDto)
    {
        var user = await _appUser.FindByIdAsync(requestUpdateUserRoleDto.AppUserId.ToString());
        var role = await _genericRepository.GetByIdAsync(requestUpdateUserRoleDto.AppRoleId);     
        if (user != null && role != null)
        {
            await _appUser.AddToRoleAsync(user, role.Name);
        }
       

    }
}