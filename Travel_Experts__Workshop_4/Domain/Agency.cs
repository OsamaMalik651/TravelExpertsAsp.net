﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Agency
    {
        public Agency()
        {
            Agents = new HashSet<Agent>();
        }

        public int AgencyId { get; set; }
        public string AgncyAddress { get; set; }
        public string AgncyCity { get; set; }
        public string AgncyProv { get; set; }
        public string AgncyPostal { get; set; }
        public string AgncyCountry { get; set; }
        public string AgncyPhone { get; set; }
        public string AgncyFax { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
    }
}
