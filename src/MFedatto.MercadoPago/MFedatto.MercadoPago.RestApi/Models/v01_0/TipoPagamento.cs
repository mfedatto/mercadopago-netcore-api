using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
    public enum TipoPagamento
    {
        /// <summary>
        /// Money in the Mercado Pago account
        /// </summary>
        AccountMoney,
        /// <summary>
        /// Printed ticket
        /// </summary>
        Ticket,
        /// <summary>
        /// Wire transfer
        /// </summary>
        BankTransfer,
        /// <summary>
        /// Payment by ATM
        /// </summary>
        Atm,
        /// <summary>
        /// Payment by credit card
        /// </summary>
        CreditCard,
        /// <summary>
        /// Payment by debit card
        /// </summary>
        DebitCard,
        /// <summary>
        /// Payment by prepaid card
        /// </summary>
        PrepaidCard
    }
}
