using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }


        //admin kullanıcı super admin için rolleri ekledik. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "e92ca0d0-cc55-4972-8b56-e61a8e415bd9";
            var superAdminRoleId = "39aa7cf7-c510-4429-b79c-5277c11f9066";
            var userRoleId = "8ba0e6be-d15d-45ae-a1fd-6ae6d2b52745";

            var roles = new List<IdentityRole>
            {

                new IdentityRole()
                {
                   Name = "Admin",
                   NormalizedName = "Admin",
                   Id = adminRoleId,
                   ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                   Name = "Super Admin",
                   NormalizedName = "Super Admin",
                   Id = superAdminRoleId,
                   ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole()
                {
                   Name = "User",
                   NormalizedName = "User",
                   Id = userRoleId,
                   ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //burda direkt olarak superAdmin bilgilerini ekledik.
            var superAdminId = "2623cddd-325c-4b6d-b16a-d9e6397d0dce";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blog.com",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                NormalizedUserName = "superadmin@blog.com".ToUpper(),
                Id = superAdminId,
            };

            //sifreyi hashleme
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //super admine tum kullanıcı rollerini verme kismi
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>()
                {
                    RoleId= adminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>()
                {
                    RoleId= superAdminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>()
                {
                    RoleId= userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }

    }
}

