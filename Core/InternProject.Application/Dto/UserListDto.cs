using InternProject.Domain.Entities;

namespace InternProject.Application.Dto;

public class UserListDto
{
    public List<AppUser>? AppUsers { get; set; }
}