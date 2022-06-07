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
    public class InterestController : Controller
    {
        private AppDbContext _context { get; }
        public InterestController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Interests.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Interests ınterests)
        {
            if (ınterests == null) return NotFound();
            _context.Interests.Add(ınterests);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Interests ınterests = _context.Interests.FirstOrDefault(x => x.Id == id);
            if (ınterests == null) return NotFound();
            return View(ınterests);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Interests ınterests)
        {
            Interests existint = _context.Interests.FirstOrDefault(c => c.Id == ınterests.Id);
            if (existint == null) return NotFound();
            existint.Title = ınterests.Title;
            existint.SubTitle = ınterests.SubTitle;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Interests interests = _context.Interests.Find(id);
            if (interests == null) return NotFound();
            _context.Interests.Remove(interests);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
