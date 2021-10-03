using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Class
    {
        public Class()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDesc { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
