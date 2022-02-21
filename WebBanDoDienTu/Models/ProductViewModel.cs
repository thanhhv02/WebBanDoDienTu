using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MetaTile { get; set; }
        public string Descriptions { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile MoreImages { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public bool? IncludedVat { get; set; }
        public int Quantity { get; set; }
        public long? CategoryId { get; set; }
        public string Detail { get; set; }
        public int? Warranty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetalKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool? Status { get; set; }
        public DateTime? TopHot { get; set; }
        public int? ViewCount { get; set; }
        public string ExistingImage { get; set; }
    }
}
