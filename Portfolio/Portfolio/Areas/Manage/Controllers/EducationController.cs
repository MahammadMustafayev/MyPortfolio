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
    public class EducationController : Controller
    {
        private AppDbContext _context { get;  }
        public EducationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Educations.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            if (education == null) return NotFound();
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Education education = _context.Educations.FirstOrDefault(x => x.Id == id);
            if (education == null) return NotFound();
            return View(education);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            Education existedc = _context.Educations.FirstOrDefault(x => x.Id == education.Id);
            if (existedc == null) return NotFound();
            existedc.SchoolName = education.SchoolName;
            existedc.PresentTime = education.PresentTime;
            existedc.PastTime = education.PastTime;
            existedc.GpaDegree = education.GpaDegree;
            existedc.EducationName = education.EducationName;
            existedc.Degree = education.Degree;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Education education = _context.Educations.Find(id);
            if (education == null) return NotFound();
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
