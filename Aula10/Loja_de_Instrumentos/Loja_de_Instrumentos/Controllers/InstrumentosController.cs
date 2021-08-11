using Loja_de_Instrumentos.Models;
using Loja_de_Instrumentos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Controllers
{
    public class InstrumentosController : Controller
    {
        IInstrumentosService _service, _sqlService, _staticService;

        public InstrumentosController(IInstrumentosService service, InstrumentosSQLService sqlService, InstrumentosStaticService staticService)
        {
            _service = service;
            _sqlService = sqlService;
            _staticService = staticService;
        }

        private void SelectService(string service = "sql")
        {
            switch (service)
            {
                case "sql":
                    _service =_sqlService;
                    break;
                case "static":
                    _service = _staticService;
                    break;
                default:
                    _service = _sqlService;
                    break;
            }
        }
        private void SelectViewBag(string service, bool order = false)
        {
            SelectService(service);
            if (service == "sql")
            {
                ViewBag.source = "sql";
            }
            ViewBag.order = order;
            ViewBag.total = _service.GetAll().Count;
            ViewBag.sum = _service.GetAll().Sum(x => x.Price);
            ViewBag.maxprice = _service.GetAll().Find(x => x.Price == _service.GetAll().Max(x => x.Price)).Brand 
                + " " + _service.GetAll().Find(x => x.Price == _service.GetAll().Max(x => x.Price)).Model;
        }
        public IActionResult Index(string search, string type, bool order = false, string service = "sql")
        {
            

            SelectViewBag(service, order);
            
     
            return View(_service.GetAll(search, type, order)); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instrumento instrumento)
        {
            if (!ModelState.IsValid) return View(instrumento);

            if (_service.Create(instrumento))
            {
                return RedirectToAction(nameof(Index));
            }
                
            else
                return View(instrumento);
        }
        public IActionResult Read(int id)
        {
            Instrumento instrumento = _service.Get(id);
            return instrumento != null ? View(instrumento) : NotFound();
        }
        public IActionResult Update(int id)
        {

            Instrumento instrumento = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return View(instrumento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Instrumento instrumentoUpdate)
        {
            if (!ModelState.IsValid) return View(instrumentoUpdate);
            if (_service.Update(instrumentoUpdate))
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
            Instrumento instrumento = _service.GetAll().FirstOrDefault(x => x.Id == id);
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }
    }
}
