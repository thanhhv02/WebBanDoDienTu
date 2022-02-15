using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
    }
}
