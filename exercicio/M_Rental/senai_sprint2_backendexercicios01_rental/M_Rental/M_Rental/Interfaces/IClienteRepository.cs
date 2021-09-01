using M_Rental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();

        ClienteDomain BuscarPorId(int idCliente);

        void Cadastrar(ClienteDomain novoCliente);

        void AtualizarIdUrl(int idCliente, ClienteDomain cliente);

        void Deletar(int idCliente);
    }
}
