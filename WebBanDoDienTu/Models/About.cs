using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class About
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTile { get; set; }
        public string Descriptions { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public int? Warranty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetalKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
    }
}
