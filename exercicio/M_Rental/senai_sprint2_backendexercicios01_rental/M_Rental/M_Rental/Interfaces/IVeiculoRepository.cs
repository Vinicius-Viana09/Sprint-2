using M_Rental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculoDomain novoVeiculo);

        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculo);

        void Deletar(int idVeiculo);
    }
}
