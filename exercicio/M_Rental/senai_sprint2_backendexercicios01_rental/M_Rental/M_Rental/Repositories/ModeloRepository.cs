using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        public void AtualizarIdUrl(int idModelo, ModeloDomain modelo)
        {
            throw new NotImplementedException();
        }

        public ModeloDomain BuscarPorId(int idModelo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ModeloDomain novoModelo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idModelo)
        {
            throw new NotImplementedException();
        }

        public List<ModeloDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
