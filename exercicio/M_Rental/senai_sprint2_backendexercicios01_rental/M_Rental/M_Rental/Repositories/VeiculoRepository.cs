using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RJD23R9\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=VINICIUS09";

        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE VEICULO SET placaVeiculo = @novoPlacaVeiculo WHERE idVeiculo = @idVeiAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoPlacaVeiculo", veiculoAtualizado.placaVeiculo);
                    cmd.Parameters.AddWithValue("@idVeiAtualizado", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo FROM VEICULO WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO VEICULO (idModelo,idMarca,placaVeiculo) VALUES (@idModelo, @idMarca, @placaVeiculo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idmarca", novoVeiculo.idMarca);
                    cmd.Parameters.AddWithValue("@nomeModelo", novoVeiculo.placaVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idVeiculo,placaVeiculo,idMarca,idModelo FROM VEICULO;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            placaVeiculo = rdr[1].ToString(),

                            idMarca = Convert.ToInt32(rdr[2]),

                            idModelo = Convert.ToInt32(rdr[3])

                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
            }

            return listaVeiculos;
        }
    }
}
