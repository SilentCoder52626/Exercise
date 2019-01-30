using Exercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.ViewModel
{
    public class CustomerFormViewModel
    {
        
        public List<MembershipType> MembershipTypes { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customers customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            BirthDate = customer.BirthDate;
            IsSubscribed = customer.IsSubscribed;
            MembershipTypeId = customer.MembershipTypeId;
        }

    }
}