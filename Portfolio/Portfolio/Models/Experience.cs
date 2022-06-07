using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string WorkName { get; set; }
        public string CompanyName { get; set; }
        public string PresentTime { get; set; }
        public string PastTime { get; set; }
        public string WorkDesc { get; set; }
    }
}
