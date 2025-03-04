﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}