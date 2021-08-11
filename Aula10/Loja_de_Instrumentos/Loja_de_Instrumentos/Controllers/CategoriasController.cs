using Loja_de_Instrumentos.Models;
using Loja_de_Instrumentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Loja_de_Instrumentos.Controllers
{
    public class CategoriasController : Controller
    {
        ICategoriaService _service;
        IInstrumentosService _instrumentosService;
        public CategoriasController(ICategoriaService service, IInstrumentosService instrumentosService)
        {
            _service = service;
            _instrumentosService = instrumentosService;
        }
        public IActionResult Index()
        {
           return View(_service.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var instrumentos = _instrumentosService.GetAll().Select(x => new { x.Id, name = x.Brand + " " + x.Model }).Where(x => !_service.GetAll().Any(y => x.Id == y.InstrumentoId));
            ViewBag.listaDeInstrumentos = new SelectList(instrumentos, "Id", "name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (!ModelState.IsValid) return View(categoria);

            if (_service.Create(categoria))
            {
                return RedirectToAction(nameof(Index));
            }

            else
                return View(categoria);
        }
        public IActionResult Read(string categoria)
        {
            ViewBag.listaDeInstrumentos = _instrumentosService.GetAll().Where(x => _service.GetAll().Where(x=> x.InstrumentoCategoria == categoria).Any(y => x.Id == y.InstrumentoId));
            return View(_service.Get(categoria));
        }
        public IActionResult Update(int id)
        {
            Categoria categoria = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Categoria categoriaUpdate)
        {
            if (!ModelState.IsValid) return View(categoriaUpdate);
            if (_service.Update(categoriaUpdate))
            {

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
        public IActionResult Delete(int? id)
        {
            if (_service.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
        public IActionResult Confirm(int? id)
        {
            Categoria categoria = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return categoria != null ? View(categoria) : RedirectToAction(nameof(Index));
        }

    }
}
