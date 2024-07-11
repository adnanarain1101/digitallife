using Dapper;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Ocsp;
using Store_Dashboard.DBContext;
using Store_Dashboard.DTOs;
using Store_Dashboard.Models;
using Store_Dashboard.Repositories.InterFace;
using Store_Dashboard.Utills;
using System.Data;

namespace Store_Dashboard.Repositories
{
    public class UserRepository : IUserRepository
    {
        IDapperContext _context;
        public UserRepository(IDapperContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string Email)
        {
            
            using IDbConnection db = _context.ConnectionCreate();

            User? user = db.Query<User>("SELECT * FROM users WHERE Email=@Email", new { Email }).SingleOrDefault();
            
            return user;
        }


        public bool Add(AddUserRequest request)
        {
            using IDbConnection db = _context.ConnectionCreate();

            int result = db.Execute($"INSERT INTO `users`(`Name`, `Email`, `PhoneNumber`, `CountryCode`, `Country`, `ImageUrl`, `RoleId`, `PasswordHash`, `CreatedOnUTC`) VALUES (@Name,@Email,@PhoneNumber,92,'PK',@ImageUrl,@RoleId,@PasswordHash,'{DateTime.UtcNow}')",request);
            return result > 0;
        }


        public List<GetAllUsersResponse> GetAll()
        {
            using IDbConnection db = _context.ConnectionCreate();

            string query = "SELECT * FROM users";

            return db.Query<GetAllUsersResponse>(query).ToList();
        }



        public bool Update (UpdateUserRequest request)
        {
            using IDbConnection db = _context.ConnectionCreate();

            int result = db.Execute($"UPDATE `users` SET ,`Name`=@Name,`Email`=@Email,`PhoneNumber`=@PhoneNumber,`CountryCode`=@CountryCode,`Country`=@Country,`ImageUrl`=@ImageUrl,`RoleId`=@RoleId,`PasswordHash`=@PasswordHash,`CreatedOnUTC`={DateTime.UtcNow} WHERE UserId = {request.UserId}",request);

            return result > 0;
        }

        public bool Delete(int id)
        {

            using IDbConnection db = _context.ConnectionCreate();
            int result = db.Execute($"DELETE FROM `users` WHERE UserId={id}");
            return result > 0;
        }
    }
}

