using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CursoADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SalvarCliente("Islana", "islanasilvaa@gmail.com", "123456");
            ExcluirCliente(3);
            ListarClientes();
        }
        public static void ListarClientes()
        {
            using (var conn = Conexao.ConnSQL())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Cliente order by id_cliente";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Nome"]);
                        Console.WriteLine(dr["Email"]);
                    }
                }
            }
        }
        public static void SalvarCliente(string nome, string email, string senha)
        {
            using (var conn = Conexao.ConnSQL())
            {
                try
                {
                    
                    SqlCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd.CommandText = "INSERT INTO Cliente (Nome, Email, Senha) VALUES(@Nome, @Email, @Senha)";
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw new Exception("Erro ao salvar cliente.");
                }

            }
        }
        public static void ExcluirCliente(int id)
        {
            using (var conn = Conexao.ConnSQL())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE Cliente WHERE Id_Cliente = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw new Exception($"Erro ao excluir cliente. {e.Message}");
                }


            }
        }
    }
} 