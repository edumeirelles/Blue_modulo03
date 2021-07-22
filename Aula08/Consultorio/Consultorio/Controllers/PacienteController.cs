using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index(int id)
        {
            //List<Paciente> pacientesTodos = getPaciente();
            //List<Paciente> pacienteFiltrados = new();

            //foreach (Paciente p in pacientesTodos)
            //{
            //    if (p.Id == id)
            //    {
            //        pacienteFiltrados.Add(p);
            //    }
            //}
            //ViewBag.listaPacientes = id == 0 ? pacientesTodos : pacienteFiltrados;
            //List<Paciente> pacientesTodos = getPaciente();
            ViewBag.listaPacientes = id == 0 ? getPaciente() : getPaciente().FindAll(p => p.Id == id);
            return View();
            
        }

       

        List<Paciente> getPaciente()
        {
            List<Paciente> listaPacientes = new();
            listaPacientes.Add(new Paciente { Id = 1, Name = "Eduardo" });
            listaPacientes.Add(new Paciente { Id = 2, Name = "Zé" });
            listaPacientes.Add(new Paciente { Id = 3, Name = "Jão" });
            return listaPacientes;
        }
    }
}
