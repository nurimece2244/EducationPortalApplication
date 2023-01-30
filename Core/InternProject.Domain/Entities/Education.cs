namespace InternProject.Domain.Entities;

public class Education
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public string? Name { get; set; }
    public int Duration { get; set; }
    public string? Type { get; set; }
    public bool Status { get; set; }
    public int EducationCategoryId { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public AppUser? AppUser { get; set; }
    public EducationCategory? EducationCategory { get; set; }
    public ICollection< AssignedEducation>? AssignedEducations { get; set; }

}