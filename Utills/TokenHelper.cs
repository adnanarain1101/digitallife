using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Store_Dashboard.Utills
{
    public class TokenHelper : ITokenHelper    {
        IConfiguration _configuration;
        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(int UserId, string Name, string Email,int RoleId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims: [
                  new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
                  new Claim(JwtRegisteredClaimNames.Name, Name),
                  new Claim(JwtRegisteredClaimNames.Email, Email),
                  new Claim("RoleId", RoleId.ToString()),
              ],
              expires: DateTime.Now.AddDays(2),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }

        public bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };

                SecurityToken validatedToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public string GetUserId(string authToken)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var validationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = false,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = _configuration["Jwt:Issuer"],
        //        ValidAudience = _configuration["Jwt:Issuer"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
        //    };

        //    SecurityToken validatedToken;
        //    ClaimsPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

        //    var data = principal.Claims.Where(o => o.Type == "UserId").FirstOrDefault();
        //    var userId = data.Value;

        //    return userId;
        //}

    }
}
