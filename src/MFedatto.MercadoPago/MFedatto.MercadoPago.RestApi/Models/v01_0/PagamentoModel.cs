using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
    public class PagamentoModel
    {
        /// <summary>
        /// Identificador de pagamento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id do pagador
        /// </summary>
        public PagadorModel Payer { get; set; }
        /// <summary>
        /// Custo do produto
        /// </summary>
        public double TransactionAmount { get; set; }

        /// <summary>
        /// Identificação do vendedor
        /// </summary>
        public string CollectorId { get; set; }
        /// <summary>
        /// Tipo de pagamento
        /// </summary>
        public TipoOperacao OperationType { get; set; }
        /// <summary>
        /// Data de criação do pagamento
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Data de aprovação do pagamento
        /// </summary>
        public DateTime? DateApproved { get; set; }
        /// <summary>
        /// Data da última modificação
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }
        /// <summary>
        /// Data de liberação do pagamento
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }
        /// <summary>
        /// Indica se o pagamento é processado em ambiente de sandbox ou produção
        /// </summary>
        public bool LiveMode { get; set; } = false;
        public MoedaPagamento? CurrencyId { get; set; }
        public double? TransactionAmountRefunded { get; set; }
        public double? CupomAmount { get; set; }
        public int? CampaingId { get; set; }
        public string CupomCode { get; set; }
        public StatusPagamento? Status { get; set; }
        /// <summary>
        /// Tipo do meio de pagamento escolhido
        /// </summary>
        public TipoPagamento? PaymentTypeId { get; set; }
    }
}
