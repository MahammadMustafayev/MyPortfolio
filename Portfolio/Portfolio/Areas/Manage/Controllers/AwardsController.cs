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
    public class AwardsController : Controller
    {
        private AppDbContext _context { get;  }
        public AwardsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Awards.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Awards awards)
        {
            if (awards == null) return NotFound();
            _context.Awards.Add(awards);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Awards awards = _context.Awards.FirstOrDefault(x => x.Id == id);
            if (awards == null) return NotFound();
            return View(awards);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Awards awards)
        {
            Awards existawards = _context.Awards.FirstOrDefault(x => x.Id == awards.Id);
            if (existawards == null) return NotFound();
            existawards.CertificateName = awards.CertificateName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Awards awards = _context.Awards.Find(id);
            if (awards == null) return NotFound();
            if (awards.IsDeleted == true)
            {
                awards.IsDeleted = false;
            }
            awards.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
