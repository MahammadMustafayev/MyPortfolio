using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModel
{
    public class HomeVM
    {
        public List<About> Abouts { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Interests> Interests { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Awards> Awards { get; set; }
    }
}
