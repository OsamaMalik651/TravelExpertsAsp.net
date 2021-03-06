using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Region
    {
        public Region()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
