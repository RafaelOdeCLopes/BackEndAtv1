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
    public class EventoController : Controller
    {
        public Context context;

        public EventoController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Eventos.Include(f => f.Participantes));
        }

        public IActionResult Create()
        {
            ViewBag.ParticipanteID = new SelectList(context.Participantes.OrderBy(f => f.Nome), "ParticipanteID", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Evento evento)
        {
            context.Add(evento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var evento = context.Eventos.Include(f => f.Participantes).FirstOrDefault(p => p.EventoID == id);
            return View(evento);
        }
        public IActionResult Edit(int id)
        {
            var evento = context.Eventos.Find(id);
            ViewBag.ParticipanteID = new SelectList(context.Participantes.OrderBy(f => f.Nome), "ParticipanteID", "Nome");
            return View(evento);
        }

        [HttpPost]
        public IActionResult Edit(Evento evento)
        {
            context.Entry(evento).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var evento = context.Eventos.Include(f => f.Participantes).FirstOrDefault(p => p.EventoID == id);
            return View(evento);
        }

        [HttpPost]
        public IActionResult Delete(Evento evento)
        {
            context.Eventos.Remove(evento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
