namespace InternProject.Application.Dto;

public class EducationDto
{
    public string? Name { get; set; }
    public int Duration { get; set; }
    public string? Type { get; set; }
    public bool Status { get; set; }
    public int EducationCategoryId { get; set; }
    
    public int AppUserId { get; set; }
}