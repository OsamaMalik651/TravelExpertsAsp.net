using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Address")]
        public string CustAddress { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        [Display(Name = "City")]
        public string CustCity { get; set; }
        [Required(ErrorMessage = "Please enter Province code. [eg. AB, BC, ON]")]
        [Display(Name = "Province")]
        public string CustProv { get; set; }
        [Required(ErrorMessage = "Please Enter Postal Code")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Postal code is invalid.")] // US or Canada
        [Display(Name = "Postal Code")]
        public string CustPostal { get; set; }  
        [Display(Name = "Country")]
        public string CustCountry { get; set; }
        [Display(Name = "Phone")]
        [RegularExpression("^[(]\\d{3}[)]\\s\\d{3}[-]\\d{4}$",
        ErrorMessage = "Plesae enter your phone number in (999) 999-9999 format")]
        public string CustHomePhone { get; set; }
        [Display(Name = "Business Phone")]
        [Required(ErrorMessage = "Please Enter Phone number")]
        [RegularExpression("^[(]\\d{3}[)]\\s\\d{3}[-]\\d{4}$",
        ErrorMessage = "Plesae enter your phone number in (999) 999-9999 format")]
        public string CustBusPhone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email address")]
        [DataType(DataType.EmailAddress)]
        public string CustEmail { get; set; }
        public int? AgentId { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }

        public string CustFullName => CustFirstName + " " + CustLastName; 
    }
}
