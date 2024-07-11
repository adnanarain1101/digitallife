namespace Store_Dashboard.DTOs
{
    public class UserRegistrationRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public IFormFile Image { get; set; }
        public string Password { get; set; }
    }
}
