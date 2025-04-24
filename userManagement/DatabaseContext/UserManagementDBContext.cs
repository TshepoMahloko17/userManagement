using Microsoft.EntityFrameworkCore;
using userManagement.Entities;

namespace userManagement.DatabaseContext
{
    public class UserManagementDBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<PermissionGroups> PermissionGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=UserManager;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
