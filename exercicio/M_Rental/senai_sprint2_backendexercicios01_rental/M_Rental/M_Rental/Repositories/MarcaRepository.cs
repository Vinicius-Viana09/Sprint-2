using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private string stringConexao = "Data Source=DESKTOP-RJD23R9\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=VINICIUS09";

        public void AtualizarIdUrl(int idMarca, MarcaDomain marcaAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeMarca = @novoNomeMarca WHERE idAluguel = @idMarcaAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeMarca", marcaAtualizada.nomeMarca);
                    cmd.Parameters.AddWithValue("@idMarcaAtualizado", idMarca);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            throw new NotImplementedException();
        }

        public MarcaDomain BuscarPorId(int idMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idMarca FROM MARCA WHERE idMarca = @idMarca";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idMarca", idMarca);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MarcaDomain marcaBuscado = new MarcaDomain
                        {
                            idMarca = Convert.ToInt32(reader["idMarca"]),

                        };

                        return marcaBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(MarcaDomain novaMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO MARCA (nomeMarca) VALUES (@nomeMarca)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeMarca", novaMarca.nomeMarca);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM MARCA WHERE idMarca = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idMarca);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<MarcaDomain> ListarTodos()
        {
            List<MarcaDomain> listaMarca = new List<MarcaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idMarca,nomeMarca FROM MARCA;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        MarcaDomain marca = new MarcaDomain()
                        {
                            idMarca = Convert.ToInt32(rdr[0]),

                            nomeMarca = rdr[1].ToString(),

                        };

                        listaMarca.Add(marca);
                    }
                }
            }

            return listaMarca;
        }
    }
}
