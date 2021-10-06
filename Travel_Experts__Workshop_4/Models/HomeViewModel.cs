using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Experts__Workshop_4.Domain;

namespace Travel_Experts__Workshop_4.Models
{
    public class HomeViewModel
    {

        public List<Package> Packages { get; set; }
        public List<Agency> Agency { get; set; }
         public List<Agent> Agents { get; set; }

        
    }
}
