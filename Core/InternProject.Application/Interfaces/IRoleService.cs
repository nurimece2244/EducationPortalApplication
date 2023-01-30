using InternProject.Application.Dto.RoleDto;

namespace InternProject.Application.Interfaces;

public interface IRoleService
{
    Task AddRole(RequestAddRoleDto requestAddRoleDto);

    Task UpdateRole(RequestUpdateRoleDto requestUpdateRoleDto);

    Task DeleteRole(int id);

    Task UpdateUserRole(RequestUpdateUserRoleDto requestUpdateUserRoleDto);

}