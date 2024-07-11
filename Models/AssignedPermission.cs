namespace Store_Dashboard.Models
{
    public class AssignedPermission
    {
        public int AssignedId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime CreatedOnUTC { get; set; }

    }
}
