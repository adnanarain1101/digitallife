using Dapper;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Ocsp;
using Store_Dashboard.DBContext;
using Store_Dashboard.Models;
using System.Data;

namespace Store_Dashboard.Utills
{
    public class DatabaseSeeding
    {
        IDapperContext _context;
        public DatabaseSeeding(IDapperContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            using IDbConnection db = _context.ConnectionCreate();

            var Roles = GetUserRoles();
            var Users = GetUsers();
            var Permissions = GetPermissions();
            var AssignedPermissions = GetAssignedPermissions();
            foreach (UserRole role in Roles)
            {
                db.Execute("INSERT INTO `userroles`(`RoleId`, `Name`, `IsBultin`, `CreatedOnUTC`) VALUES (@RoleId,@Name,@IsBultin, @CreatedOnUTC)", role);
            }
            foreach (User user in Users)
            {
                db.Execute($"INSERT INTO `users`(`UserId`,`Name`, `Email`, `PhoneNumber`, `CountryCode`, `Country`, `ImageUrl`, `RoleId`, `PasswordHash`, `CreatedOnUTC`) VALUES (@UserId, @Name,@Email,@PhoneNumber,92,PK,@ImageUrl,@RoleId,@PasswordHash, @CreatedOnUTC)", user);
            }
            foreach (Permission permission in Permissions)
            {
                db.Execute($"INSERT INTO `rolepermissions`(`PermissionId`, `Code`, `Description`, `CreatedOnUTC`) VALUES(@PermissionId, @Code,@Description , @CreatedOnUTC)", permission);
            }
            foreach (AssignedPermission assignedpermission in AssignedPermissions)
            {
                db.Execute($"INSERT INTO `assignedpermissions`(`AssignedId`, `RoleId`, `PermissionId`, `CreatedOnUTC`) VALUES (@AssignedId,@RoleId,@PermissionId,@CreatedOnUTC)", assignedpermission);
            }

        }

        private List<UserRole> GetUserRoles()
        {
            return new List<UserRole>()
            {
                new UserRole
                {
                    RoleId = 1,
                    Name = "Admin",
                    IsBultin = true,
                    CreatedOnUTC = DateTime.UtcNow,
                },
                new UserRole
                {
                    RoleId = 2,
                    Name = "Customer",
                    IsBultin = true,
                    CreatedOnUTC = DateTime.UtcNow,
                },
                new UserRole
                {
                    RoleId = 3,
                    Name = "Manager",
                    IsBultin = true,
                    CreatedOnUTC = DateTime.UtcNow,
                },
            };
        }

        private List<User> GetUsers()
        {
            return new List<User>()
            {
                new User
                {
                    UserId = 1,
                    Name = "Adnan",
                    Email = "adnan@gmail.com",
                    PhoneNumber = 0309222,
                    Country = "PK",
                    CountryCode = 92,
                    ImageUrl = "",
                    PasswordHash = EncryptionDecryption.Encrypt("test"),
                    RoleId = 1,
                    CreatedOnUTC = DateTime.UtcNow,
                }
            };
        }

        private List<Permission> GetPermissions()
        {
            return new List<Permission>()
            {
                new Permission
                {
                    PermissionId = 1,
                    Code = "GetUser",
                    Description = "This User has GetUser Permission",
                    CreatedOnUTC = DateTime.UtcNow,
                },
                new Permission
                {
                    PermissionId = 2,
                    Code = "AddUser",
                    Description = "This User has AddUser Permission",
                    CreatedOnUTC = DateTime.UtcNow,
                },
                new Permission
                {
                    PermissionId = 3,
                    Code = "UpdateUser",
                    Description = "This User has UpdateUser Permission",
                    CreatedOnUTC = DateTime.UtcNow,
                },
                new Permission
                {
                    PermissionId = 4,
                    Code = "DeleteUser",
                    Description = "This User has DeleteUser Permission",
                    CreatedOnUTC = DateTime.UtcNow,
                }
            };
        }

        private List<AssignedPermission> GetAssignedPermissions()
        {

            return new List<AssignedPermission>()
            {
                new AssignedPermission
                {
                    AssignedId =1,
                    RoleId = 1,
                    PermissionId = 1,
                    CreatedOnUTC = DateTime.UtcNow,

                }, 
                new AssignedPermission
                {
                    AssignedId = 2,
                    RoleId = 1,
                    PermissionId = 2,
                    CreatedOnUTC = DateTime.UtcNow,

                },
                new AssignedPermission
                {
                    AssignedId = 3,
                    RoleId = 1,
                    PermissionId = 3,
                    CreatedOnUTC = DateTime.UtcNow,

                },
                new AssignedPermission
                {
                    AssignedId = 4,
                    RoleId = 1,
                    PermissionId = 4,
                    CreatedOnUTC = DateTime.UtcNow,

                },

            };


        }
    }
}
