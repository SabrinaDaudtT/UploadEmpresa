using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UploadEmpresa.Models;
using System.Net.Http;
using Newtonsoft.Json;
using UploadEmpresa.Models.Response;

namespace UploadEmpresa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region DetalheS

        [HttpGet]
        [Route("Home/_Detalhes")]
        public ActionResult _Detalhes(string cnpj)
        {
            var client = new RestClient("https://receitaws.com.br/v1/cnpj/" + cnpj);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode.ToString().Equals("OK"))
            {
                EmpresaResponse objEmpresa = JsonConvert.DeserializeObject<EmpresaResponse>(response.Content);

                var retLista = new EmpresaViewModel
                {
                    cnpj = objEmpresa.cnpj,
                    nome = objEmpresa.nome,
                    fantasia = objEmpresa.fantasia,
                    situacao_especial = objEmpresa.situacao_especial,
                    data_situacao = objEmpresa.data_situacao,
                    logradouro = objEmpresa.logradouro,
                    numero = objEmpresa.numero,
                    cep = objEmpresa.cep,
                    municipio = objEmpresa.municipio,

                };
                return View(retLista);
            }
            else
            {
                    var ret = new HomeResponse { Mensagem = "A Busca não retornou resultado!" };
                    return View(ret);
            }
        }

        #endregion
    }
}
