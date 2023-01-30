using InternProject.Application.Dto.RoleDto;
using InternProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.WebAPI.Controllers;

public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("AddRole")]
    public async Task AddRole([FromBody] RequestAddRoleDto requestAddRoleDto)
    {
        await _roleService.AddRole( requestAddRoleDto);

    }
    
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("UpdateRole")]
    public async Task UpdateRole([FromBody] RequestUpdateRoleDto requestUpdateRoleDto)
    {
        await _roleService.UpdateRole(requestUpdateRoleDto);

    }

    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("DeleteRole")]
    public async Task DeleteRole([FromQuery] int id)
    {
        await _roleService.DeleteRole( id);

    }
    
    [HttpPost("UpdateUserRole")]
    public async Task UpdateUserRole( [FromBody] RequestUpdateUserRoleDto requestUpdateUserRoleDto)
    {
      await _roleService.UpdateUserRole(requestUpdateUserRoleDto);
        
       
    }
}