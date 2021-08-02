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
        InstrumentosSQLService service;

        public InstrumentosController(InstrumentosSQLService service)
        {
            this.service = service;
        }
        public IActionResult Index(string search, string type, bool order = false)
        {

            ViewBag.order = order;
            ViewBag.msg = "";
            //ViewBag.total = Instrumentos().Count;
            //ViewBag.sum = Instrumentos().Sum(x => x.Price);
            //ViewBag.maxprice = Instrumentos().Find(x => x.Price == Instrumentos().Max(x => x.Price)).Brand + " " + Instrumentos().Find(x => x.Price == Instrumentos().Max(x => x.Price)).Model;
            

            return View(service.GetAll(search, type, order)); //InstrumentosStaticService.getAll
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Instrumento instrumento)
        //{
        //    ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " criado com sucesso";
        //    ViewBag.order = false;

        //    InstrumentosStaticService service = new();

        //    if (service.create(instrumento))
        //    {
        //        return RedirectToAction(nameof(Index)); //InstrumentosStaticService.create(instrumento)
        //    }
        //    else
        //    {
        //        return View(instrumento);
        //    }


        //}

        public IActionResult Read(string type, int? id)
        {
            Instrumento instrumento = service.GetInstruments().FirstOrDefault(x =>  x.Type == type && x.Id == id) ;
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }

        //public IActionResult Update(int? id)
        //{
        //    Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
        //    return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        //}
        //[HttpPost]
        //public IActionResult Update(Instrumento instrumentoUpdate)
        //{
        //    List<Instrumento> instrumentos = GetInstruments();
        //    Instrumento instrumento = instrumentos.FirstOrDefault(x => x.Id == instrumentoUpdate.Id);
        //    if (instrumento == null) return RedirectToAction(nameof(Index));

        //    var indice = instrumentos.IndexOf(instrumento);
        //    instrumentos[indice] = instrumentoUpdate;


        //    ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " editado com sucesso";
        //    ViewBag.order = false;
        //    ViewBag.total = instrumentos.Count;
        //    ViewBag.sum = instrumentos.Sum(x => x.Price);
        //    ViewBag.maxprice = instrumentos.Find(x => x.Price == instrumentos.Max(x => x.Price)).Brand + " " + instrumentos.Find(x => x.Price == instrumentos.Max(x => x.Price)).Model;
        //    return View(nameof(Index), instrumentos);
        //}
        //public IActionResult Delete(int? id)
        //{
        //    List<Instrumento> instrumentos = GetInstruments();
        //    Instrumento instrumento = instrumentos.FirstOrDefault(x => x.Id == id);
        //    if (instrumento != null)
        //    {

        //        ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " removido com sucesso";
        //        ViewBag.order = false;
        //        ViewBag.total = instrumentos.Count;
        //        ViewBag.sum = instrumentos.Sum(x => x.Price);
        //        ViewBag.maxprice = instrumentos.Find(x => x.Price == instrumentos.Max(x => x.Price)).Brand + " " + instrumentos.Find(x => x.Price == instrumentos.Max(x => x.Price)).Model;

        //        instrumentos.Remove(instrumento);
        //        return View(nameof(Index), instrumentos);
        //    }

        //    return instrumento == null ?
        //        NotFound() :
        //        View(nameof(Index));
        //}

        //public IActionResult Confirm(int? id)
        //{
        //    Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
        //    return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        //}





    }
}
