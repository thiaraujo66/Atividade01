using Atividade01.Interfaces;
using Atividade01.Models;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Atividade01.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        private string _connectionString;

        public ClienteDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Atualizar(Cliente pCliente)
        {
            using(SqlConnection con = new SqlConnection(_connectionString)) 
            {
                string query = "UPDATE Clientes SET Nome = @Nome, Email = @Email WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", pCliente.Nome);
                cmd.Parameters.AddWithValue("@Email", pCliente.Email);
                cmd.Parameters.AddWithValue("@Id", pCliente.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente BuscarPorId(int pId)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Cliente() 
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Email = reader.GetString(2),
                    };
                }
                else 
                {
                    return null;
                }
            }
        }

        public void Deletar(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString)) 
            {
                string query = "DELETE FROM Clientes WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", pId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Incluir(string pNome, string pEmail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", pNome);
                command.Parameters.AddWithValue("@Email", pEmail);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Cliente> ListarTodos()
        {
            List<Cliente> retorno = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Clientes";

                SqlCommand command = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    Cliente cliente = new Cliente() 
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    retorno.Add(cliente);
                }
            }

            return retorno;
        }
    }
}
