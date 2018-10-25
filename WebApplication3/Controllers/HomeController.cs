using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private NoteRepository repo;

        public HomeController()
        {
            repo = new NoteRepository();
        }

        public ActionResult Index()
        {           
            return View(NoteRepository.Notes);
        }

        public ActionResult Create(string title, string desc)
        {
            var note = new Note(title, desc);

            NoteRepository.Notes.Add(note.Id, note);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var note = repo.GetNoteById(id);

            if (note == null)
            {
                return HttpNotFound();
            }

            NoteRepository.Notes.Remove(note.Id);

            return RedirectToAction("Index");
        }
    }
}