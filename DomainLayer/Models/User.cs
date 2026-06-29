using DomainLayer.HelpersAndOptions;

namespace DomainLayer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<User> Users { get; set; }
    }
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
    public class UserPermission
    {
        public int PermissionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum UserPermissions
    {
        ReadProducts = 1,
        AddProducts,
        EditProducts,
        DeleteProducts
    }
}
