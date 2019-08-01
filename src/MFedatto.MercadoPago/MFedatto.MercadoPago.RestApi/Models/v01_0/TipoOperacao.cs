using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
    public enum TipoOperacao
    {
        /// <summary>
        /// Typification by default of a purchase being paid using Mercado Pago
        /// </summary>
        RegularPayment,
        /// <summary>
        /// Funds transfer between two users
        /// </summary>
        MoneyTransfer,
        /// <summary>
        /// Automatic recurring payment due to an active user subscription
        /// </summary>
        RecurringPayment,
        /// <summary>
        /// Money income in the user's account
        /// </summary>
        AccountFund,
        /// <summary>
        /// Addition of money to an existing payment, done in Mercado Pago's site
        /// </summary>
        PaymentAddition,
        /// <summary>
        /// Recharge of a user's cellphone account
        /// </summary>
        CellphoneRecharge,
        /// <summary>
        /// Payment done through a Point Of Sale
        /// </summary>
        PosPayment
    }
}
