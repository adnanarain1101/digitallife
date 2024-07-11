namespace Store_Dashboard.DTOs
{
    public class UpdateRolePermissionRequest
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
