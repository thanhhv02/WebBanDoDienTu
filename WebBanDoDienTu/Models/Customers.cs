﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class Customers
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
    }
}
