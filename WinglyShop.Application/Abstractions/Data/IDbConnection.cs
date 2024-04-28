using Microsoft.Data.SqlClient;

namespace WinglyShop.Application.Abstractions.Data;

public interface IDbConnection
{
	SqlConnection CreateConnection();
}

