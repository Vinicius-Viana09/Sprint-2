using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RJD23R9\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=VINICIUS09";

        public void AtualizarIdUrl(int idModelo, ModeloDomain modeloAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeModelo = @novoNomeModelo WHERE idModelo = @idModAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeModelo", modeloAtualizado.nomeModelo);
                    cmd.Parameters.AddWithValue("@idModAtualizado", idModelo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ModeloDomain BuscarPorId(int idModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idModelo FROM MODELO WHERE idModelo = @idModelo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", idModelo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ModeloDomain modeloBuscado = new ModeloDomain
                        {
                            idModelo = Convert.ToInt32(reader["idModelo"]),

                        };

                        return modeloBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ModeloDomain novoModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO MODELO (nomeModelo,idMarca) VALUES (@nomeModelo,@idMarca)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeModelo", novoModelo.nomeModelo);
                    cmd.Parameters.AddWithValue("@idMarca", novoModelo.idMarca);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM MODELO WHERE idModelo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idModelo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ModeloDomain> ListarTodos()
        {
            List<ModeloDomain> listaModelo = new List<ModeloDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idModelo,nomeModelo,idMarca FROM MODELO;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ModeloDomain modelo = new ModeloDomain()
                        {
                            idModelo = Convert.ToInt32(rdr[0]),

                            nomeModelo = rdr[1].ToString(),

                            idMarca = Convert.ToInt32(rdr[2])

                        };

                        listaModelo.Add(modelo);
                    }
                }
            }

            return listaModelo;
        }
    }
}
