namespace Store_Dashboard.Repositories.InterFace
{
    public interface IPermissionRepository
    {
        public bool IsRoleHasPermission(int RoleId, string Permission);
    }
}
