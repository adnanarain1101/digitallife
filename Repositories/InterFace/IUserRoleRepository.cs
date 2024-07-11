using Store_Dashboard.DTOs;
using Store_Dashboard.Models;


namespace Store_Dashboard.Repositories.InterFace
{
    public interface IUserRoleRepository 
    {
        public bool Add(AddRoleRequest request);
        public List<GetAllRolesResponse> GetAll();
        public bool Update(UpdateRoleRequest request);
        public bool Delete(int id);




    }
}
