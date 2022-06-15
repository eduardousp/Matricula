using matricula.domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsereAluno.Controllers
{
    public class AlunoController : Controller
    {
        IAlunoService _service;
        public AlunoController()
        {
            _service = new AlunoService();

        }
        // GET: MatriculaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MatriculaController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(_service.List());
        }

        // GET: MatriculaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatriculaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MatriculaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MatriculaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MatriculaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MatriculaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
