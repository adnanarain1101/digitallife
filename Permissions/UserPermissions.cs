namespace Store_Dashboard.Permissions
{
    public class UserPermissions
    {
        private const string Base = "User";
        private const string Separator = ".";

        public const string Create = Base + Separator + "Create";
        public const string Read = Base + Separator + "Read";
        public const string Update = Base + Separator + "Update";
        public const string Delete = Base + Separator + "Delete";
    }
}
