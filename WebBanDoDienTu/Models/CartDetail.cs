using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public long ProductId { get; set; }
        public short? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
