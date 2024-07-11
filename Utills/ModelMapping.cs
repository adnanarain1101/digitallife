using AutoMapper;
using Store_Dashboard.DTOs;
using Store_Dashboard.Models;

namespace Store_Dashboard.Utills
{
    public class ModelMapping : Profile
    {
        public ModelMapping() {
            CreateMap<UserRegistrationRequest, AddUserRequest>();
        }
    }
}
