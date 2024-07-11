using Store_Dashboard.DBContext;
using Store_Dashboard.DTOs;
using Store_Dashboard.Repositories.InterFace;
using System.Data;
using Dapper;

namespace Store_Dashboard.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        IDapperContext _context;
        public UserRoleRepository(IDapperContext context)
        {
            _context = context;
        }

        public bool Add(AddRoleRequest request)
        {
            using IDbConnection db = _context.ConnectionCreate();

            int result = db.Execute($"INSERT INTO `userroles`(`Name`,`IsBultin`, `CreatedOnUTC`) VALUES (@Name,{0},'{DateTime.UtcNow}')", request);
            return result > 0;
        }

        public List<GetAllRolesResponse> GetAll()
        {
            using IDbConnection db = _context.ConnectionCreate();

            string query = "SELECT * FROM userroles";

            return db.Query<GetAllRolesResponse>(query).ToList();
        }


        public bool Update(UpdateRoleRequest request)
        {
            using IDbConnection db = _context.ConnectionCreate();

            int result = db.Execute($"UPDATE `userroles` SET ,`Name`=@Name WHERE UserId = {request.RoleId}", request);

            return result > 0;
        }

        public bool Delete(int id)
        {

            using IDbConnection db = _context.ConnectionCreate();
            int result = db.Execute($"DELETE FROM `userroles` WHERE UserId={id}");
            return result > 0;
        }

    }
}
