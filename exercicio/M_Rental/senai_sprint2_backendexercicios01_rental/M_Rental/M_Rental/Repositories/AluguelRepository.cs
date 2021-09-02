using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando Login e Senha.
        /// integrated security = Faz a autenticação com o usuario do sistema (Windows).
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = "Data Source=DESKTOP-RJD23R9\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=VINICIUS09";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";


        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET idCliente = @novoIdCliente, idVeiculo = @novoIdVeiculo, dataRetirada = @novoDataRetirada, dataDevolucao = @novoDataDevolucao WHERE idAluguel = @idAluAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoIdCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@novoIdVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoDataRetirada", aluguelAtualizado.dataRetirada);
                    cmd.Parameters.AddWithValue("@novoDataDevolucao", aluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@idAluAtualizado", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel FROM GENERO WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain generoBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),

                        };

                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo aluguel.
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel com as informações que serão cadastradas.</param>
        public void Cadastrar(AluguelDomain novoAluguel)
        {
            // Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO ALUGUEL (idCliente, idVeiculo, dataRetirada, dataDevolucao) VALUES (@idCliente, @idVeiculo, @dataRetirada, @dataDevolucao)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@nomeGenero", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            //Cria uma listaGeneros onde serão armazenados os dados.
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            //Declara a SQL connection con passando a string de conexao como parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectALL = "SELECT idAluguel,idCliente,idVeiculo,dataRetirada,dataDevolucao FROM ALUGUEL;";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declara o SqlDataReader rar para percorrer a tabela do banco de dados.
                SqlDataReader rdr;

                //Declara o SQLCommand cmd passando a query que sera executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    //executa a query e armaneza os dados no rdr.
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //Instancia um objeto genero do tipo ClienteDomain
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            //atribui a propriedade idAluguel o valor da primeira coluna na tabela do banco de dados.
                            idAluguel = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade idCliente o valor da segunda coluna na tabela do banco de dados.
                            idCliente = Convert.ToInt32(rdr[1]),

                            //atribui a propriedade idVeiculo o valor da terceira coluna na tabela do banco de dados.
                            idVeiculo = Convert.ToInt32(rdr[2]),

                            //atribui a propriedade dataRetirada o valor da quarta coluna na tabela do banco de dados.
                            dataRetirada = rdr[3].ToString(),

                            //atribui a propriedade dataDevolucao o valor da quinta coluna na tabela do banco de dados.
                            dataDevolucao = rdr[4].ToString()
                        };

                        //Adicionar o objeto aluguel criado a lista listaAlugueis.
                        listaAluguel.Add(aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }
}
