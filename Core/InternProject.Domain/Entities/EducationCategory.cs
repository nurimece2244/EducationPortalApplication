using Azure.Core;

namespace InternProject.Domain.Entities;

public class EducationCategory 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public bool IsDeleted { get; set; }
  //  public int AppUserId { get; set; } 
    public ICollection<Education>? Educations { get; set; }
}