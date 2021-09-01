using M_Rental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ModeloRepository
    /// </summary>
    interface IModeloRepository
    {
        List<ModeloDomain> ListarTodos();

        ModeloDomain BuscarPorId(int idModelo);

        void Cadastrar(ModeloDomain novoModelo);

        void AtualizarIdUrl(int idModelo, ModeloDomain modelo);

        void Deletar(int idModelo);
    }
}
