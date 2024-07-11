using System.Data;

namespace Store_Dashboard.DBContext
{
    public interface IDapperContext
    {
        public IDbConnection ConnectionCreate();
    }
}
