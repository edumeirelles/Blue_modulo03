using Loja_de_Instrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Controllers
{
    public class InstrumentosController : Controller
    {
        public IActionResult Index(string search)
        {
            List<Instrumento> instrumentos = GetInstruments();

            ViewBag.order = false;
            ViewBag.msg = "";
            ViewBag.total = instrumentos.Count;
            ViewBag.sum = instrumentos.Sum(x => x.Price);
            ViewBag.maxprice = instrumentos.Find(x => x.Price == instrumentos.Max(x=> x.Price)).Brand +" "+ instrumentos.Find(x => x.Price == instrumentos.Max(x => x.Price)).Model;

            return View(search == null ? instrumentos : instrumentos.FindAll(x => x.Brand.ToUpper().Contains(search.ToUpper()) || x.Model.ToUpper().Contains(search.ToUpper())));
        }
    
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instrumento instrumento)
        {
            List<Instrumento> instrumentos = GetInstruments();
            instrumento.Id = instrumentos.Last().Id + 1;
            instrumentos.Add(instrumento);
            ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " criado com sucesso";
            ViewBag.order = false;
            return View(nameof(Index), instrumentos);
        }

        public IActionResult Read(int? id)
        {
            Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(Instrumento instrumentoUpdate)
        {
            List<Instrumento> instrumentos = GetInstruments();
            Instrumento instrumento = instrumentos.FirstOrDefault(x => x.Id == instrumentoUpdate.Id);
            if (instrumento == null) return RedirectToAction(nameof(Index));

            var indice = instrumentos.IndexOf(instrumento);
            instrumentos[indice] = instrumentoUpdate;
            ViewBag.order = false;
            ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " editado com sucesso";
            return View(nameof(Index), instrumentos);
        }
        public IActionResult Delete(int? id)
        {
            List<Instrumento> instrumentos = GetInstruments();
            Instrumento instrumento = instrumentos.FirstOrDefault(x => x.Id == id);
            if (instrumento != null)
            {
                ViewBag.order = false;
                ViewBag.msg = "Instrumento " + instrumento.Brand + " " + instrumento.Model + " removido com sucesso";
                instrumentos.Remove(instrumento);
                return View(nameof(Index), instrumentos);
            }
            
            return instrumento == null ?
                NotFound() :
                View(nameof(Index));
        }
        
        public IActionResult Confirm(int? id)
        {
            Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
            return instrumento != null ? View(instrumento) : RedirectToAction(nameof(Index));
        }

        public IActionResult Order()
        {
            List<Instrumento> instrumentosByName = GetInstruments().OrderBy(x => x.Model).ToList();
            ViewBag.msg = "";
            ViewBag.order = true;
            ViewBag.total = instrumentosByName.Count;
            ViewBag.sum = instrumentosByName.Sum(x => x.Price);
            ViewBag.maxprice = instrumentosByName.Find(x => x.Price == instrumentosByName.Max(x => x.Price)).Brand + " " + instrumentosByName.Find(x => x.Price == instrumentosByName.Max(x => x.Price)).Model;
            
            return View(nameof(Index),instrumentosByName);
        }

        List<Instrumento> GetInstruments()
        {
            List<Instrumento> instruments = new();

            instruments.Add(new Instrumento
            {
                Id = 1,
                Type = "Guitarra",
                Brand = "Fender",
                Model = "Stratocaster",
                Description = "A Fender Stratocaster é um modelo de guitarra elétrica desenhada por Leo Fender, " +
                "George Fullerton e Freddie Tavares em 1954.",
                Price = 9999.99,
                Link = "https://images.musicstore.de/images/1280/fender-75th-anniversary-commemorative-stratocaster_1_GIT0055575-000.jpg"
            });
            instruments.Add(new Instrumento
            {
                Id = 2,
                Type = "Guitarra",
                Brand = "Gibson",
                Model = "SG",
                Description = "Gibson SG é um dos mais conhecidos modelo de guitarra " +
                "elétrica, de corpo sólido surgido no começo dos anos 60.",
                Price = 12999.99,
                Link = "https://reference.vteximg.com.br/arquivos/ids/285617-1000-1000/frontal.jpg?v=636286502567700000"
            });
            instruments.Add(new Instrumento
            {
                Id = 3,
                Type = "Violão",
                Brand = "Martin",
                Model = "DJR2E",
                Description = "A C.F. Martin & Company é uma fabricante de violões dos Estados Unidos, estabelecida" +
                " em 1833 por Christian Frederick Martin, que nasceu em 1796 na cidade de Markneukirchen na Alemanha.",
                Price = 5999.99,
                Link = "https://images-na.ssl-images-amazon.com/images/I/815LrvftyWL.jpg"
            });
            instruments.Add(new Instrumento
            {
                Id = 4,
                Type = "Violão",
                Brand = "Epiphone",
                Model = "DR-100",
                Description = "The DR-100 features chrome hardware, a 25.5' scale, 1.68' nut width, set mahogany neck with dot inlays, mahogany body and select spruce top.",
                Price = 1499.99,
                Link = "https://sc1.musik-produktiv.com/pic-100009980xl/epiphone-dr-100-na.jpg"
            });
            instruments.Add(new Instrumento
            {
                Id = 5,
                Type = "Guitarra",
                Brand = "Gibson",
                Model = "Les Paul",
                Description = "Gibson Les Paul é uma guitarra de corpo sólido que começou a ser vendida em 1952.",
                Price = 24999.99,
                Link = "https://x5music.vteximg.com.br/arquivos/ids/183227-1920-1920/GUITARRA-GIBSON-TRADITIONAL-LESPAUL-Honey-Burst-COM-CASE.jpg"
            });

            return instruments;
        }

    }
}
