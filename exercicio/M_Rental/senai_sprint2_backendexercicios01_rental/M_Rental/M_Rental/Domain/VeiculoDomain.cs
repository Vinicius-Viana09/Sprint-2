using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Rental.Domain
{
    /// <summary>
    /// Classe que representa a entidade (tabela) VEICULO
    /// </summary>
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }

        public int idModelo { get; set; }

        public int idMarca { get; set; }

        public string placaVeiculo { get; set; }

 
    }
}
