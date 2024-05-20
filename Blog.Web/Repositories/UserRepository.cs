using Blog.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users= await authDbContext.Users.ToListAsync();

            //superadmine kimse uılasmasin ve kontrol edemesin istiyoruz. aslinda burda vt de superadmin var mi yok mu onu kontrol ediyoruz. 
            var superAdminUser = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email == "superadmin@blog.com");

            if(superAdminUser is not null) //users tablosundan superadmini kaldirdik. 
            {
                users.Remove(superAdminUser);
            }

            return users;

        }
    }
}
