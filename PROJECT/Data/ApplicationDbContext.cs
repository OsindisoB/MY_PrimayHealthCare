using PROJECT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using System.Reflection.Emit;

namespace PROJECT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Counselling> CounsellingAppointments { get; set; }
        public DbSet<Counsellors> Counsellors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.Entity<Counsellors>().HasData(
            //    new Counsellors { CounsellorId = 1, Name = "Dr. Pillay(Mr)" },
            //    new Counsellors { CounsellorId = 2, Name = "Dr. Ngoqo(Mrs)" },
            //    new Counsellors { CounsellorId = 3, Name = "Dr. Bunyula(Ms)" }
   

            builder.HasDefaultSchema("dbo");
            builder.Entity<ApplicationUser>(
                entity =>
                {

                    entity.ToTable(name: "Users");
                });

            builder.Entity<IdentityRole>(
                entity =>
                {

                    entity.ToTable(name: "Roles");
                });

            builder.Entity<IdentityUserRole<string>>(
               entity =>
               {

                   entity.ToTable(name: "UserRoles");
               });

            builder.Entity<IdentityUserClaim<string>>(
              entity =>
              {

                  entity.ToTable(name: "UserClaims");
              });

            builder.Entity<IdentityUserLogin<string>>(
              entity =>
              {

                  entity.ToTable(name: "UserLogin");
              });

            builder.Entity<IdentityUserToken<string>>(
              entity =>
              {

                  entity.ToTable(name: "UserTokens");
              });

            builder.Entity<IdentityRoleClaim<string>>(
              entity =>
              {

                  entity.ToTable(name: "RoleClaims");
              });
        }


    }

}