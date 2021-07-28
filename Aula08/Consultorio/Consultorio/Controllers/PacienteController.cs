using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Consultorio.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index(int? id)
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
            
            //ViewBag.listaPacientes = id == null ? getPaciente() : getPaciente().FindAll(p => p.Id == id);


            List<Paciente> pacientes = id == null ? getPaciente() : getPaciente().FindAll(p => p.Id == id);
            return View(pacientes);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Paciente paciente)
        {
            
            List<Paciente> pacientes = getPaciente();
            paciente.Id = pacientes.Count + 1;
            pacientes.Add(paciente);
            
            return View("Index",pacientes);
        }

        List<Paciente> getPaciente()
        {
            List<Paciente> listaPacientes = new();
            listaPacientes.Add(new Paciente { Id = 1, Name = "Eduardo" , DataNasc = new DateTime(1985, 01, 15), Descricao = "Aluno" });
            listaPacientes.Add(new Paciente { Id = 2, Name = "Zé" , DataNasc = new DateTime(1990, 01, 03) , Descricao = "Aluno"});
            listaPacientes.Add(new Paciente { Id = 3, Name = "Jão" , DataNasc = new DateTime(1976, 04, 26), Descricao = "Professor"});
            return listaPacientes;
        }
    }
}
