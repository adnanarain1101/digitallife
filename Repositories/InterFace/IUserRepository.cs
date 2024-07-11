using Store_Dashboard.DTOs;
using Store_Dashboard.Models;
using System.Data;

namespace Store_Dashboard.Repositories.InterFace
{
    public interface IUserRepository
    {
        public User? GetUserByEmail(string Email);
        public List<GetAllUsersResponse> GetAll();
        public bool Add(AddUserRequest request);
        public bool Update(UpdateUserRequest request);
        public bool Delete(int id);


    }
}