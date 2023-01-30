namespace InternProject.Domain.Entities;

public class AssignedEducation
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public int EducationId { get; set; }
    public bool CompletedEducation { get; set; }
    public bool FavoriteEducation { get; set; }
    
    public bool IsDeleted { get; set; }
    public Education Education { get; set; } =  null! ;
    public AppUser AppUser { get; set; } = null!;
}