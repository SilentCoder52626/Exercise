using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Exercise.ViewModel;

namespace Exercise.Models
{
    

    public class Customers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribed { get; set; }    
        
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
    }
}

