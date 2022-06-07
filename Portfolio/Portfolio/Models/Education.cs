using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string PastTime { get; set; }
        public string PresentTime { get; set; }
        public string Degree { get; set; }
        public string EducationName { get; set; }
        public double GpaDegree { get; set; }
    }
}
