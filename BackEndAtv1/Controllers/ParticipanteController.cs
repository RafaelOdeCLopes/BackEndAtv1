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
    public class ProdutoController : Controller
    {
        public Context context;

        public ProdutoController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Participantes.Include(f => f.Evento));
        }

        public IActionResult Create()
        {
            ViewBag.EventoID = new SelectList(context.Eventos.OrderBy(f => f.Nome), "FabricanteID", "Nome");
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
            var produto = context.Participantes.Include(f => f.Evento).FirstOrDefault(p => p.ParticipanteID == id);
            return View(produto);
        }
        public IActionResult Edit(int id)
        {
            var produto = context.Participantes.Find(id);
            ViewBag.FabricanteID = new SelectList(context.Eventos.OrderBy(f => f.Nome), "EventoID", "Nome");
            return View(produto);
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