using Microsoft.AspNetCore.Identity;

namespace InternProject.Domain.Entities;

public class AppRole:IdentityRole<int>
{
    public bool IsDeleted { get; set; }
  
}