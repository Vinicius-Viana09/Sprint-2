using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Domain
{
    /// <summary>
    /// Classe que representa a entidade (tabela) ALUGUEL
    /// </summary>
    public class AluguelDomain
    {
        public int idAluguel { get; set; }

        public int idCliente { get; set; }

        public int idVeiculo { get; set; }

        public string dataRetirada { get; set; }

        public string dataDevolucao { get; set; }

    }
}
