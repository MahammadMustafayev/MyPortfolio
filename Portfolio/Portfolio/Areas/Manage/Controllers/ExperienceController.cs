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
    public class ExperienceController : Controller
    {
        private AppDbContext _context { get; }
        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Experiences.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Experience experience)
        {
            if (experience == null) return NotFound();
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Experience experience = _context.Experiences.FirstOrDefault(x => x.Id == id);
            if (experience == null) return NotFound();
            return View(experience);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Experience experience)
        {
            Experience existexp = _context.Experiences.FirstOrDefault(x => x.Id == experience.Id);
            if (existexp == null) return NotFound();
            existexp.WorkName = experience.WorkName;
            existexp.CompanyName = experience.CompanyName;
            existexp.WorkDesc = experience.WorkDesc;
            existexp.PastTime = experience.PastTime;
            existexp.PresentTime = experience.PresentTime;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Experience experience = _context.Experiences.Find(id);
            if (experience == null) return NotFound();
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
