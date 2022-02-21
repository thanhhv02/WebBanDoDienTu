using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class Slide
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Status { get; set; }
    }
}
