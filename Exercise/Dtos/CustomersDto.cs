using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.Dtos
{
    public class CustomersDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribed { get; set; }

        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}