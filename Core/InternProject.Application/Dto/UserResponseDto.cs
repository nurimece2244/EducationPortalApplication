using Microsoft.AspNetCore.Identity;

namespace InternProject.Application.Dto;

public class UserResponseDto 
{
  
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    
    public int ManagerId { get; set; }
  
}