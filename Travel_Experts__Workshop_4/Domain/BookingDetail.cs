using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public double? ItineraryNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TripStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TripEnd { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? AgencyCommission { get; set; }
        public int? BookingId { get; set; }
        public string RegionId { get; set; }
        public string ClassId { get; set; }
        public string FeeId { get; set; }
        public int? ProductSupplierId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Class Class { get; set; }
        public virtual Fee Fee { get; set; }
        public virtual ProductsSupplier ProductSupplier { get; set; }
        public virtual Region Region { get; set; }
    }
}
