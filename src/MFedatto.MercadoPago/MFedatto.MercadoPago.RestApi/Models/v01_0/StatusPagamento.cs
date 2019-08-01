using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFedatto.MercadoPago.RestApi.Models.v01_0
{
    public enum StatusPagamento
    {
        Pending,
        Approved,
        Authorized,
        InProcess,
        InMediation,
        Rejected,
        Cancelled,
        Refunded,
        ChargedBack
    }
}
