//Date: October 11, 2021
//Projetct: PROJ-009-003 – Project Workshop 4, Travel Experts Website

//Group 1, Team 1:
//Osama Malik		SAIT Student ID 880863
//Tracy Crape		SAIT Student ID 420488
//Adesola Oyatunji	SAIT Student ID 838997

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable
//Database package details
namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        [Display(Name = "Package ID")]
        public int PackageId { get; set; }
        [Display(Name = "Package Name")]
        public string PkgName { get; set; }
        [Display(Name = "Package Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? PkgStartDate { get; set; }
        [Display(Name = "Package End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? PkgEndDate { get; set; }
        [Display(Name = "Package Description")]
        public string PkgDesc { get; set; }
        [Display(Name = "Package Price")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal PkgBasePrice { get; set; }
        [Display(Name = "Agency Commission")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? PkgAgencyCommission { get; set; }

        //public string PkgImg { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
    }
}
