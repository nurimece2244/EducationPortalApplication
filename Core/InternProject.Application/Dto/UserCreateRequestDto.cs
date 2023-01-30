namespace InternProject.Application.Dto;

public class UserCreateRequestDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public int ManagerId { get; set; }
}