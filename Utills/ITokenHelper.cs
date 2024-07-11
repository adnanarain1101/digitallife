namespace Store_Dashboard.Utills
{
    public interface ITokenHelper
    {
        public string GenerateToken(int UserId, string Name, string Email, int RoleId);
        public bool ValidateToken(string authToken);
    }
}
