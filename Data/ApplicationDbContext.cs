using HobbiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HobbiesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base (options)
        {
            
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<HobbyEnrollment> HobbyEnrollments { get; set; }
    }
    
}
