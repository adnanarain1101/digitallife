using Dapper;
using Store_Dashboard.DBContext;
using Store_Dashboard.Repositories.InterFace;
using System.Data;

namespace Store_Dashboard.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        IDapperContext _context;
        public PermissionRepository(IDapperContext context)
        {
            _context = context;
        }

        public bool IsRoleHasPermission(int RoleId,string Permission)
        {
            using IDbConnection db = _context.ConnectionCreate();
            int result = db.Query<string>("SELECT ap.RoleId FROM assignedpermissions ap INNER JOIN permissions p ON ap.PermissionId = p.PermissionId WHERE ap.RoleId = @RoleId AND p.Code = @Permission", new {RoleId, Permission}).Count();
            return result > 0;
        }
    }
}
