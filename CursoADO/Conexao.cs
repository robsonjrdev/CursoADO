using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoADO
{
    public class Conexao
    {
        private static string connString = "Server=localhost;Database=ADWI; User Id=robson;Password=robson";

        public static SqlConnection ConnSQL()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                return conn;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao se conectar ao banco");
            }
          
        }
    }
}
