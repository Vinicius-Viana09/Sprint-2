using M_Rental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorId(int idAluguel);

        void Cadastrar(AluguelDomain novoAluguel);

        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguel);

        void Deletar(int idAluguel);
    }
}
