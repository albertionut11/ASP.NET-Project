using DAW_Project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace DAW_Project.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider
serviceProvider)
        {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService
            <DbContextOptions<ApplicationDbContext>>()))
            {
                // Verificam daca in baza de date exista cel putin un rol
                // insemnand ca a fost rulat codul
                // De aceea facem return pentru a nu insera rolurile inca o data
                // Acesta metoda trebuie sa se execute o singura data
                if (context.Roles.Any())
                {
                    return; // baza de date contine deja roluri
                }
                // CREAREA ROLURILOR IN BD
                // daca nu contine roluri, acestea se vor crea
                context.Roles.AddRange(
                new IdentityRole { Id = "3d73c57d-ece2-4b18-8364-162a52ff4aff", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = "3f81d37a-57d8-4b84-a007-151284bc5019", Name = "Editor", NormalizedName = "Editor".ToUpper() },
                new IdentityRole { Id = "9070d330-24fb-47eb-8acd-7b4f78f53675", Name = "User", NormalizedName = "User".ToUpper() }
                );
                // o noua instanta pe care o vom utiliza pentru crearea parolelor utilizatorilor
                 // parolele sunt de tip hash
                 var hasher = new PasswordHasher<ApplicationUser>();
                // CREAREA USERILOR IN BD
                // Se creeaza cate un user pentru fiecare rol
                context.Users.AddRange(
                new ApplicationUser
                {
                    Id = "dc9e6d85-6762-49d2-bafc-d77e20d31aa5",
                    // primary key
                    UserName = "admin@test.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin1!")
                },
               new ApplicationUser
                {

                    Id = "c8803a2a-0924-4b49-bcc8-dd5d110b4582",
                    // primary key
                    UserName = "editor@test.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "EDITOR@TEST.COM",
                    Email = "editor@test.com",
                    NormalizedUserName = "EDITOR@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "Editor1!")
                },
               new ApplicationUser
               {
                   Id = "ad6cfe04-9b55-4cc2-89ea-1d01824641c9",
                   // primary key
                   UserName = "user@test.com",
                   EmailConfirmed = true,
                   NormalizedEmail = "USER@TEST.COM",
                   Email = "user@test.com",
                   NormalizedUserName = "USER@TEST.COM",
                   PasswordHash = hasher.HashPassword(null, "User1!")
               }
               );
                // ASOCIEREA USER-ROLE
                context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    RoleId = "3d73c57d-ece2-4b18-8364-162a52ff4aff",
                    UserId = "dc9e6d85-6762-49d2-bafc-d77e20d31aa5"
                },
               new IdentityUserRole<string>
               {
                   RoleId = "3f81d37a-57d8-4b84-a007-151284bc5019",
                   UserId = "c8803a2a-0924-4b49-bcc8-dd5d110b4582"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "9070d330-24fb-47eb-8acd-7b4f78f53675",
                   UserId = "ad6cfe04-9b55-4cc2-89ea-1d01824641c9"
               }
                );
                context.SaveChanges();
            }
        }
    }
}

