using M_Rental.Domain;
using M_Rental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void AtualizarIdUrl(int idCliente, ClienteDomain cliente)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idCliente)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
