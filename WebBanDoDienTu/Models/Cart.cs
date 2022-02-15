using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
