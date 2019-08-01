using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
    public class PagadorModel
    {
        /// <summary>
        /// Identificador de pagamento
        /// </summary>
        public int? Id { get; set; }
        
        public string Email { get; set; }
        public TipoEntidade? EntityType { get; set; }
        public TipoPagador? Type { get; set; }
    }
}
