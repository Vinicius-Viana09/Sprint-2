using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RJD23R9\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=VINICIUS09";

        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenomeCliente = @novoSobrenomeCliente WHERE idAluguel = @idCliAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@idCliAtualizado", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente) VALUES (@nomeCliente, @sobrenomeCliente)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idCliente,nomeCliente,sobrenomeCliente FROM CLIENTE;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                          
                            nomeCliente = rdr[1].ToString(),
                            
                            sobrenomeCliente = rdr[2].ToString()
                        };

                        listaCliente.Add(cliente);
                    }
                }
            }

            return listaCliente;
        }
    }
}
