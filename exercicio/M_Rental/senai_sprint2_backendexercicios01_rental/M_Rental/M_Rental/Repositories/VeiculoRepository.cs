using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculo)
        {
            throw new NotImplementedException();
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
