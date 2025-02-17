﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //data annotation
        //overriding the default convensions
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
       
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
       
        
        [Display(Name="Date Of Birth")]
        public DateTime? Birthdate{ get; set; }
    }
}