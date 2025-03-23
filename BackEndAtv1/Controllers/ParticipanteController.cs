using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAtv1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndAtv1.Controllers
{
    public class ParticipanteController : Controller
    {
        public Context context;

        public ParticipanteController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Participantes.Include(f => f.Evento));
        }

        public IActionResult Create()
        {
            ViewBag.EventoID = new SelectList(context.Eventos.OrderBy(f => f.Nome), "EventoID", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Participante participante)
        {
            context.Add(participante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var participante = context.Participantes.Include(f => f.Evento).FirstOrDefault(p => p.ParticipanteID == id);
            return View(participante);
        }
        public IActionResult Edit(int id)
        {
            var participante = context.Participantes.Find(id);
            ViewBag.EventoID = new SelectList(context.Eventos.OrderBy(f => f.Nome), "EventoID", "Nome");
            return View(participante);
        }

        [HttpPost]
        public IActionResult Edit(Participante participante)
        {
            context.Entry(participante).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var participante = context.Participantes.Include(f => f.Evento).FirstOrDefault(p => p.ParticipanteID == id);
            return View(participante);
        }

        [HttpPost]
        public IActionResult Delete(Participante participante)
        {
            context.Participantes.Remove(participante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
