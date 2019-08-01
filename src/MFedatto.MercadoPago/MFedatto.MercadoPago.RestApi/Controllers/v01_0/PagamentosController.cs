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
        public async Task<IActionResult> ReceberPagamento([FromBody] PagamentoModel model, [FromHeader] string publicKey, [FromHeader] string accessToken, [FromHeader] string liveMode)
        {
            try
            {
                return Ok(await _mercadoPagoBaseAddress
                    .AppendPathSegment("payments")
                    .SetQueryParams(new
                    {
						access_token = accessToken
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