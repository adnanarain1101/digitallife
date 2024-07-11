namespace Store_Dashboard.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsBultin { get; set; }
        public DateTime CreatedOnUTC { get; set; }

    }
}
