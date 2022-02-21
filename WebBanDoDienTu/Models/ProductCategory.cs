using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTile { get; set; }
        public long? ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        public string SeoTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetalKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }
    }
}
