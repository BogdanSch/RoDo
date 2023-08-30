using Microsoft.EntityFrameworkCore;
using RoDo.Model;

namespace RoDo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db");
    }
}
