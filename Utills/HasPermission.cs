using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Data;
using Store_Dashboard.Utills;
using System.IdentityModel.Tokens.Jwt;
using Store_Dashboard.Repositories.InterFace;

namespace Store_Dashboard.Attributes
{
    public class HasPermissionAttribute : TypeFilterAttribute
    {
        public HasPermissionAttribute(string claim) : base(typeof(HasPermissionFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class HasPermissionFilter : IAuthorizationFilter
    { 
        readonly string _claim;
        readonly IConfiguration _config;
        readonly ITokenHelper _tokenHelper;
        readonly IPermissionRepository _rolePermissionsRepository;

        public HasPermissionFilter(string claim, IConfiguration config, ITokenHelper tokenHelper, IPermissionRepository rolePermissionsRepository)
        {
            _claim = claim;
            _config = config;
            _tokenHelper = tokenHelper;
            _rolePermissionsRepository = rolePermissionsRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers.Authorization.ToString();
            if(String.IsNullOrEmpty(token))
            {
                //context.Result = new UnauthorizedObjectResult("Token is not valid");
                context.Result = new RedirectResult("/");

                return;
            }
            bool IsValid = _tokenHelper.ValidateToken(token.Replace("Bearer ",""));
            if (!IsValid)
            {
                //context.HttpContext.Response.Cookies.Delete()
                context.Result = new UnauthorizedResult();
                return;
            }
            int.TryParse(context.HttpContext.User.Claims.Where(o => o.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value, out int UserId);
            int.TryParse(context.HttpContext.User.Claims.Where(o => o.Type == "RoleId").FirstOrDefault()?.Value, out int RoleId);
            if (UserId == null || RoleId == null)
            {
                //context.HttpContext.Response.Cookies.Delete()
                context.Result = new UnauthorizedResult();
                return;
            }
            bool result = _rolePermissionsRepository.IsRoleHasPermission(RoleId, _claim);
            if(!result)
            {
               
                context.Result = new UnauthorizedObjectResult("You don't have permission");
                return;
            }
        }
    }

}
