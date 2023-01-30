using Microsoft.AspNetCore.Identity;

namespace InternProject.Domain.Entities;

public class AppUser : IdentityUser<int> 
{
   public int ManagerId { get; set; }
   public bool IsDeleted { get; set; }
   public ICollection <Education>? Educations { get; set; }
   public ICollection< AssignedEducation>? AssignedEducations { get; set; }
   
}