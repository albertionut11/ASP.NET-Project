using DAW_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<Domain> Domains { get; set; }

    }


}