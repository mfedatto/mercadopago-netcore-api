using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
	public class MetodoPagamentoModel
	{
		/// <summary>
		/// Id do meio de pagamento
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Nome do meio de pagamento
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Tipo de meio de pagamento
		/// </summary>
		public TipoPagamento PaymentTypeId { get; set; }
	}
}
