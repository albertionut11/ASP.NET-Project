using DAW_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // definire relatii cu modelele Domain si Article (FK)
            modelBuilder.Entity<Article>()
                .HasOne(ab => ab.Domain)
                .WithMany(ab => ab.Articles)
                .HasForeignKey(ab => ab.Domain_id);

            // definire relatii cu modelele Article si Modification (FK)

            modelBuilder.Entity<Modification>()
                .HasOne(ab => ab.Article)
                .WithMany(ab => ab.Modifications)
                .HasForeignKey(ab => ab.Article_Id);

        }




    }
}