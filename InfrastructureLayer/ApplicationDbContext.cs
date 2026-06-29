using Microsoft.EntityFrameworkCore;
using DomainLayer;
using DomainLayer.Models;
namespace InfrastructureLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(x => x.Roles).WithMany(x => x.Users).UsingEntity<UserRole>(x =>
            {
                x.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
                x.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
                x.HasKey(x => new { x.RoleId, x.UserId });
            });
            modelBuilder.Entity<UserPermission>().ToTable("UserPermissions").HasKey(x => new { x.UserId, x.PermissionId });
        }
        public DbSet<User> Users { get; set; }
    }
}
