using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.DAL;
using Portfolio.Models;
using Portfolio.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Index()
        {    
            
            HomeVM homeVM = new HomeVM
            {
                Abouts= _context.Abouts.Take(1).ToList(),
                Experiences= _context.Experiences.Take(4).ToList(),
                Educations=_context.Educations.Take(2).ToList(),
                Skills=_context.Skills.Take(10).ToList(),
                Interests=_context.Interests.Take(1).ToList(),
                Awards=_context.Awards.ToList()
            };
            return View(homeVM);
        }

       
    }
}
