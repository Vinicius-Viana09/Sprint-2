using M_Rental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório MarcaRepository
    /// </summary>
    interface IMarcaRepository
    {
        List<MarcaDomain> ListarTodos();

        MarcaDomain BuscarPorId(int idMarca);

        void Cadastrar(MarcaDomain novoMarca);

        void AtualizarIdUrl(int idMarca, MarcaDomain marca);

        void Deletar(int idMarca);
    }
}
