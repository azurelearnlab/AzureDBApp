using System.Data.SqlClient;
using AzureDBApp.Model;
namespace AzureDBApp.BAL
{
    public class ProductService
    {
        private static string db_souce = "azureleandb.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Titan$43";
        private static string db_name = "azureleanDB";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_souce;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_name;
            return new SqlConnection(_builder.ConnectionString);

        }
        public List<Product> GetProducts()
        {
            SqlConnection con = GetConnection();

            List<Product> productlst = new List<Product>();
            string sql = "SELECT productId, ProductName,Quantity FROM Products";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    productlst.Add(product);
                }
            }
            con.Close();
            return productlst;
        }
    }
}
