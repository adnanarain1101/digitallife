namespace Store_Dashboard.DTOs
{
    public class GetAllUsersResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
    }
}
