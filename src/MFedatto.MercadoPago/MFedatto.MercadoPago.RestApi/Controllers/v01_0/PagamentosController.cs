using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MFedatto.MercadoPago.RestApi.Controllers.v01_0
{
    [Controller]
    [Route("/v01_0/pagamentos")]
    public class PagamentosController : Controller
    {
        [HttpPost("pagamentos")]
        public async Task<IActionResult> ReceberPagamento()
        {
            return View();
        }
    }
}