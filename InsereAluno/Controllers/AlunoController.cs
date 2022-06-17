using matricula.domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsereAluno.Controllers
{
    
    public class AlunoController : Controller
    {
        private readonly IInserirAluno _inserirAluno;
        public AlunoController(IInserirAluno hostedService) 
        {
            _inserirAluno = hostedService;
         }
        // GET: MatriculaController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<object> Index(IFormCollection collection)
        {
            var tempo = Convert.ToUInt16(collection["tempo"].ToString())*1000;
            if (_inserirAluno.IsRunning())
            {
                _inserirAluno.StopAsync(new System.Threading.CancellationToken());
            }
            _inserirAluno.SetaTimer(tempo);
            await _inserirAluno.StartAsync(new System.Threading.CancellationToken());

            return View("Index");
        }

    

    }
}
