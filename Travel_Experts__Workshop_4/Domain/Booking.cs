using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        [Display(Name = "Booking Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BookingDate { get; set; }
        [Display(Name = "Booking Number")]
        public string BookingNo { get; set; }
        [Display(Name = "Number of Travellers")]
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        [Display(Name = "Trip Type")]
        public string TripTypeId { get; set; }
        public int? PackageId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Package Package { get; set; }
        public virtual TripType TripType { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

      
    }
}
