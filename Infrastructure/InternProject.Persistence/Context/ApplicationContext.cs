using InternProject.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Persistence.Context;

public class ApplicationContext: IdentityDbContext<AppUser,AppRole,int> 
{
    
    public ApplicationContext( DbContextOptions<ApplicationContext> options): base( options)
    {
        
    }
}
