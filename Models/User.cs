namespace Store_Dashboard.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PhoneNumber { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedOnUTC { get; set; }

    }
}