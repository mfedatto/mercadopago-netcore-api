using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFedatto.MercadoPago.RestApi.Models.v01_0;
using Microsoft.AspNetCore.Mvc;

namespace MFedatto.MercadoPago.RestApi.Controllers.v01_0
{
    [Controller]
    [Route("/v01_0/pagamentos")]
    public class PagamentosController : Controller
    {
        private readonly string _mercadoPagoBaseAddress = @"https://api.mercadopago.com/v1/";

        [HttpPost("")]
        [ProducesResponseType(1)] // Params Error.
        [ProducesResponseType(3)] // Token must be for test.
        [ProducesResponseType(4)] // The caller is not authorized to access this resource.
        [ProducesResponseType(5)] // Must provide your access_token to proceed.
        [ProducesResponseType(200)] // SUCCESS
        [ProducesResponseType(201)] // CREATED
        [ProducesResponseType(400)] // BAD_REQUEST
        [ProducesResponseType(404)] // NOT_FOUND
        [ProducesResponseType(403)] // FORBIDDEN
        [ProducesResponseType(1000)] // Number of rows exceeded the limits.
        [ProducesResponseType(1001)] // Date format must be yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        [ProducesResponseType(2000)] // Payment not found
        [ProducesResponseType(2001)] // Already posted the same request in the last minute.
        [ProducesResponseType(2004)] // POST to Gateway Transactions API fail.
        [ProducesResponseType(2002)] // Customer not found.
        [ProducesResponseType(2006)] // Card Token not found.
        [ProducesResponseType(2007)] // Connection to Card Token API fail.
        [ProducesResponseType(2009)] // Card token issuer can't be null.
        [ProducesResponseType(2060)] // The customer can't be equal to the collector.
        [ProducesResponseType(3000)] // You must provide your cardholder_name with your card data.
        [ProducesResponseType(3001)] // You must provide your cardissuer_id with your card data.
        [ProducesResponseType(3002)] // The caller is not authorized to perform this action.
        [ProducesResponseType(3003)] // Invalid card_token_id.
        [ProducesResponseType(3004)] // Invalid parameter site_id.
        [ProducesResponseType(3005)] // Not valid action, the resource is in a state that does not allow this operation. For more information see the state that has the resource.
        [ProducesResponseType(3006)] // Invalid parameter cardtoken_id.
        [ProducesResponseType(3007)] // The parameter client_id can not be null or empty.
        [ProducesResponseType(3008)] // Not found Cardtoken.
        [ProducesResponseType(3009)] // unauthorized client_id.
        [ProducesResponseType(3010)] // Not found card on whitelist.
        [ProducesResponseType(3011)] // Not found payment_method.
        [ProducesResponseType(3012)] // Invalid parameter security_code_length.
        [ProducesResponseType(3013)] // The parameter security_code is a required field can not be null or empty.
        [ProducesResponseType(3014)] // Invalid parameter payment_method.
        [ProducesResponseType(3015)] // Invalid parameter card_number_length.
        [ProducesResponseType(3016)] // Invalid parameter card_number.
        [ProducesResponseType(3017)] // The parameter card_number_id can not be null or empty.
        [ProducesResponseType(3018)] // The parameter expiration_month can not be null or empty.
        [ProducesResponseType(3019)] // The parameter expiration_year can not be null or empty.
        [ProducesResponseType(3020)] // The parameter cardholder.name can not be null or empty.
        [ProducesResponseType(3021)] // The parameter cardholder.document.number can not be null or empty.
        [ProducesResponseType(3022)] // The parameter cardholder.document.type can not be null or empty.
        [ProducesResponseType(3023)] // The parameter cardholder.document.subtype can not be null or empty.
        [ProducesResponseType(3024)] // Not valid action - partial refund unsupported for this transaction.
        [ProducesResponseType(3025)] // Invalid Auth Code.
        [ProducesResponseType(3026)] // Invalid card_id for this payment_method_id.
        [ProducesResponseType(3027)] // Invalid payment_type_id.
        [ProducesResponseType(3028)] // Invalid payment_method_id.
        [ProducesResponseType(3029)] // Invalid card expiration month.
        [ProducesResponseType(3030)] // Invalid card expiration year.
        [ProducesResponseType(4000)] // card atributte can't be null.
        [ProducesResponseType(4001)] // payment_method_id atributte can't be null.
        [ProducesResponseType(4002)] // transaction_amount atributte can't be null.
        [ProducesResponseType(4003)] // transaction_amount atributte must be numeric.
        [ProducesResponseType(4004)] // installments atributte can't be null.
        [ProducesResponseType(4005)] // installments atributte must be numeric.
        [ProducesResponseType(4006)] // payer atributte is malformed.
        [ProducesResponseType(4007)] // site_id atributte can't be null.
        [ProducesResponseType(4012)] // payer.id atributte can't be null.
        [ProducesResponseType(4013)] // payer.type atributte can't be null.
        [ProducesResponseType(4015)] // payment_method_reference_id atributte can't be null.
        [ProducesResponseType(4016)] // payment_method_reference_id atributte must be numeric.
        [ProducesResponseType(4017)] // status atributte can't be null.
        [ProducesResponseType(4018)] // payment_id atributte can't be null.
        [ProducesResponseType(4019)] // payment_id atributte must be numeric.
        [ProducesResponseType(4020)] // notificaction_url atributte must be url valid.
        [ProducesResponseType(4021)] // notificaction_url atributte must be shorter than 500 character.
        [ProducesResponseType(4022)] // metadata atributte must be a valid JSON.
        [ProducesResponseType(4023)] // transaction_amount atributte can't be null.
        [ProducesResponseType(4024)] // transaction_amount atributte must be numeric.
        [ProducesResponseType(4025)] // refund_id can't be null.
        [ProducesResponseType(4026)] // Invalid coupon_amount.
        [ProducesResponseType(4027)] // campaign_id atributte must be numeric.
        [ProducesResponseType(4028)] // coupon_amount atributte must be numeric.
        [ProducesResponseType(4029)] // Invalid payer type.
        [ProducesResponseType(4037)] // Invalid transaction_amount.
        [ProducesResponseType(4038)] // application_fee cannot be bigger than transaction_amount.
        [ProducesResponseType(4039)] // application_fee cannot be a negative value.
        [ProducesResponseType(4050)] // payer.email must be a valid email.
        [ProducesResponseType(4051)] // payer.email must be shorter than 254 characters.
        public async Task<IActionResult> ReceberPagamento([FromBody] PagamentoModel model, [FromHeader] string publicKey, [FromHeader] string accessToken, [FromHeader] string liveMode)
        {
            try
            {
                return Ok(await _mercadoPagoBaseAddress
                    .AppendPathSegment("payments")
                    .SetQueryParams(new
                    {
                        AcccessToken = accessToken
                    })
                    .PostJsonAsync(model)
                    .ReceiveJson<PagamentoModel>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}