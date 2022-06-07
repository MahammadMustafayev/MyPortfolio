using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AboutController : Controller
    {
        private AppDbContext _context { get;  }
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Abouts.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About about)
        {
            if (about == null) return NotFound();
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null) return NotFound();
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About about)
        {
            About existabout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);
            if (existabout == null) return NotFound();
            existabout.FirstName = about.FirstName;
            existabout.LastName = about.LastName;
            existabout.Desc = about.Desc;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            About about = _context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
