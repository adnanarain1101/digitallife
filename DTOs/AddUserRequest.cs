namespace Store_Dashboard.DTOs
{
    public class AddUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
}
