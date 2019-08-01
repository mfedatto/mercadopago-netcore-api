using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFedatto.MercadoPago.RestApi.Controllers.v01_0
{
	[Controller]
	[Route("/v01_0/metodos-pagamento")]
	public class MetodosPagamentoController : Controller
	{
		private readonly string _mercadoPagoBaseAddress = @"https://api.mercadopago.com/v1/";

		[HttpGet("")]
		public async Task<IActionResult> ListarMetodosPagamento([FromHeader] string publicKey, [FromHeader] string accessToken, [FromHeader] string liveMode)
		{
			try
			{
				return Ok(await _mercadoPagoBaseAddress
					.AppendPathSegment("payments")
					.SetQueryParams(new
					{
						access_token = accessToken
					})
					.GetAsync()
					.ReceiveJson<MetodoPagamentoModel>());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
	}
}