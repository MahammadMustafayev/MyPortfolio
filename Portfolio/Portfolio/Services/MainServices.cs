using Portfolio.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class MainServices
    {
        private AppDbContext  _context { get;  }
        public MainServices(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSettings()
        {
            return _context.Settings.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
