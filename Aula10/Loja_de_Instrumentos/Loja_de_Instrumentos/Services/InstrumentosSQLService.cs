using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_de_Instrumentos.Services
{
    public class InstrumentosSQLService : IInstrumentosService
    {
        LojaDeInstrumentosContext _context;
        public InstrumentosSQLService(LojaDeInstrumentosContext context)
        {
            _context = context;
        }
        public List<Instrumento> GetAll(string search = null, string type = null, bool order = false)
        {

            if (type == "Guitarra")
            {
                var guitarra = GetInstruments().FindAll(x => x.Type == type);
                return guitarra;
            }
            else if (type == "Violão")
            {
                var violao = GetInstruments().FindAll(x => x.Type == type);
                return violao;
            }
            else if (type == "Bateria")
            {
                var bateria = GetInstruments().FindAll(x => x.Type == type);
                return bateria;
            }
            else
            {
                if (order)
                    return GetInstruments().OrderBy(x => x.Model).ToList();

                if (search != null)
                    return GetInstruments().FindAll(x => x.Brand.ToUpper().Contains(search.ToUpper()) || x.Model.ToUpper().Contains(search.ToUpper()));
                return GetInstruments();
            }
        }
        public Instrumento Get(int id)
        {
            return GetInstruments().FirstOrDefault(x => x.Id == id);
        }
        public bool Create(Instrumento instrumento)
        {
            try
            {
                _context.Add(instrumento);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Instrumento instrumentoUpdate)
        {
            //var instrumentoFound = GetInstruments().FirstOrDefault(x => x.Id == instrumentoUpdate.Id);
            //if (instrumentoFound == null) return false;
            _context.Instrumento.Update(instrumentoUpdate);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int? id)
        {
            Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
            _context.Instrumento.Remove(instrumento);
            _context.SaveChanges();
            return true;
        }
        List<Instrumento> GetInstruments()
        {
            List<Instrumento> instrumentos = _context.Instrumento.ToList();
            return instrumentos;
        }


    }
}
