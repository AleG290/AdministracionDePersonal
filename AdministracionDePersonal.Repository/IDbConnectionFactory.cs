using System.Data;

namespace AdministracionDePersonal.Repository
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
