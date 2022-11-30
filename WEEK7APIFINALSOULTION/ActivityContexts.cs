using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEEK7APIFINALSOULTION.Model;

namespace WEEK7APIFINALSOULTION
{
    public class ActivityContexts: DbContext
    {
        public ActivityContexts(DbContextOptions options): base(options) { }
        public DbSet<Activity> Activitives { get; set; }
        public DbSet<User> users { get; set; }
    }
}
