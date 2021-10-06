using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Travel_Experts__Workshop_4.Domain;

namespace Travel_Experts__Workshop_4.Models
{
    public class CustomerViewModel
    {
      
        public Customer Customer { get; set; }
        public List<Booking> Bookings { get; set; }

        public List<BookingDetail> BookingDetails { get; set; }


    }
}
