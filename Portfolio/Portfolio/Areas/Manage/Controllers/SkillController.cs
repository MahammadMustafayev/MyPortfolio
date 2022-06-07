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
    public class SkillController : Controller
    {
        private AppDbContext _context { get; }
        public SkillController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Skills.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skill skill)
        {
            if (skill == null) return NotFound();
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Skill skill = _context.Skills.FirstOrDefault(x => x.Id == id);
            if (skill == null) return NotFound();
            return View(skill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Skill skill)
        {
            Skill existskill = _context.Skills.FirstOrDefault(x => x.Id == skill.Id);
            if (existskill == null) return NotFound();
            existskill.Icon = skill.Icon;
            existskill.WorkFlow = skill.WorkFlow;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Skill skill = _context.Skills.Find(id);
            if (skill == null) return NotFound();
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
