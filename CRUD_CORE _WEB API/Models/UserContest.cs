using Microsoft.EntityFrameworkCore;

namespace CRUD_CORE__WEB_API.Models
{
    public class UserContest:DbContext
    {
        public UserContest(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
