using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Services
{
    public class InstrumentosSQLService
    {
        LojaDeInstrumentosContext context;
        public InstrumentosSQLService(LojaDeInstrumentosContext context)
        {
            this.context = context;
        }
        
        public List<Instrumento> GetAll(string search, string type, bool order = false)
        {
       
            if (type == "guitarra")
            {
                var guitarra = GetInstruments().OfType<Guitarra>().ToList();
                var instrumentos = guitarra.OfType<Instrumento>().ToList();
                return instrumentos;
            }
            else if (type == "violao")
            {
                var violao = GetInstruments().OfType<Violao>().ToList();
                var instrumentos = violao.OfType<Instrumento>().ToList();
                return instrumentos;
            }
            else if (type == "bateria")
            {
                var bateria = GetInstruments().OfType<Bateria>().ToList();
                var instrumentos = bateria.OfType<Instrumento>().ToList();
                return instrumentos;
            }
            else
            {
                if (order)
                {
                    return GetInstruments().OrderBy(x => x.Model).ToList();
                }
                if (search != null)
                {
                    return GetInstruments().FindAll(x => x.Brand.ToUpper().Contains(search.ToUpper()) || x.Model.ToUpper().Contains(search.ToUpper()));
                }
                return GetInstruments();
            }

            
        }
        //public Instrumento get(int id)
        //{
        //    return GetInstruments().FirstOrDefault(x => x.Id == id);
        //}
        //public bool create(Instrumento instrumento)
        //{
        //    List<Instrumento> instrumentos = GetInstruments();
        //    instrumento.Id = instrumentos.Last().Id + 1;

        //    try
        //    {
        //        instrumentos.Add(instrumento);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool update(Instrumento instrumento)
        //{
        //    return false;
        //}
        //public bool delete(Instrumento instrumento)
        //{
        //    return false;
        //}

        public List<Instrumento> GetInstruments()
        {
            IQueryable<Instrumento> guitarra = from x in context.Guitarra select x;
            IQueryable<Instrumento> violao = from x in context.Violao select x;
            IQueryable<Instrumento> bateria = from x in context.Bateria select x;

            var instrumentos = guitarra.ToList().Union(violao.ToList().Union(bateria.ToList())).ToList();

            return instrumentos;
        }

        
    }
}
