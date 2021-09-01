using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Domain
{
    /// <summary>
    /// Classe que representa a entidade (tabela) CLIENTE
    /// </summary>
    public class ClienteDomain
    {
        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenomeCliente { get; set; }


    }
}
