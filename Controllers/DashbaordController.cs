using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Store_Dashboard.Attributes;
using Store_Dashboard.DTOs;
using Store_Dashboard.Models;
using Store_Dashboard.Permissions;
using Store_Dashboard.Repositories;
using Store_Dashboard.Repositories.InterFace;
using Store_Dashboard.ResponseMessages;
using Store_Dashboard.Utills;
using System.Data;

namespace Store_Dashboard.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        IUserRepository _userRepository;
        IUserRoleRepository _userRoleRepository;
        ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public DashboardController(IUserRepository userRepository, IUserRoleRepository userRoleRepository, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }


        [HttpPost]

        public IActionResult Login(UserLoginRequest request)
        {
            ResponseDTO response = new();
            User? user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                response.Message = UserMessages.LoginIncorrectDetailMessage;
                return Unauthorized(response);
            }

            if (!EncryptionDecryption.Match(request.Password, user.PasswordHash))
            {
                response.Message = UserMessages.LoginIncorrectDetailMessage;
                return Unauthorized(response);
            }

            string Token = _tokenHelper.GenerateToken(user.UserId, user.Name, user.Email, user.RoleId);
            response.Message = UserMessages.LoginSuccessMessage;
            response.Data = new { token = Token };
            return Ok(response);
        }



        //[HttpPost]

        //public IActionResult Signup(UserRegistrationRequest request)
        //{
        //    ResponseDTO response = new();

        //    AddUserRequest addUserRequest = _mapper.Map<UserRegistrationRequest, AddUserRequest>(request);
        //    addUserRequest.PasswordHash = EncryptionDecryption.Encrypt(request.Password);
        //    addUserRequest.ImageUrl = "";
        //    addUserRequest.RoleId = 1;
        //    if (_userRepository.Add(addUserRequest))
        //    {

        //    response.Message = UserMessages.RegistrationSuccessMessage;
        //    }
        //    else
        //    {
        //        response.Message = "Error Occured While Processing Your Request";
        //    }
        //    return Ok(response);
        //}





        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userRepository.GetAll();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [HttpPost]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            ResponseDTO response = new();


            var users = _userRepository.Update(request);
            if (!users == null)
            {

                response.Message = "User Update Successfully";
            }
            else
            {
                response.Message = "Error Occured While Processing Your Request";
            }
            return Ok(response);
        }


        [HttpPost]

        public IActionResult DeleteUser(int request)
        {
            ResponseDTO response = new();


            var users = _userRepository.Delete(request);
            if (!users == null)
            {

                response.Message = "User Delete Successfully";
            }
            else
            {
                response.Message = "Error Occured While Processing Your Request";
            }
            return Ok(response);
        }








        [HttpPost]

        public IActionResult AddRole(AddRoleRequest request)
        {
            ResponseDTO response = new();

            var user = _userRoleRepository.Add(request);
            if (!user == null)
            {

                response.Message = "Add Role Successfully";
            }
            else
            {
                response.Message = "Error Occured While Processing Your Request";
            }

            return Ok(response);
        }


        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _userRoleRepository.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public IActionResult UpdateRole(UpdateRoleRequest request)
        {
            ResponseDTO response = new();


            var users = _userRoleRepository.Update(request);
            if (!users == null)
            {

                response.Message = "Role Update Successfully";
            }
            else
            {
                response.Message = "Error Occured While Processing Your Request";
            }
            return Ok(response);
        }


        [HttpPost]

        public IActionResult DeleteRole(int id)
        {
            ResponseDTO response = new();


            var users = _userRoleRepository.Delete(id);
            if (!users == null)
            {

                response.Message = "Role Delete Successfully";
            }
            else
            {
                response.Message = "Error Occured While Processing Your Request";
            }
            return Ok(response);
        }


    }
}
