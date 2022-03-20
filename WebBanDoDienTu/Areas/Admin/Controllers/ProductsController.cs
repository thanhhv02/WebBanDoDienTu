using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BANDODIENTUContext _context;

        public ProductsController(BANDODIENTUContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
                return View(await _context.Product.ToListAsync());
        }
        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,MetaTile,Descriptions,Image,MoreImages,Price,PromotionPrice,IncludedVat,Quantity,CategoryId,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetalKeywords,MetaDescriptions,Status,TopHot,ViewCount")] ProductViewModel product)
        {
            if (product == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(product);
                string stringFileName2 = UploadFile2(product);
                var products = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    MetaTile = product.MetaTile,
                    Descriptions = product.Descriptions,
                    Image = stringFileName,
                    MoreImages = stringFileName2,
                    Price = product.Price,
                    PromotionPrice = product.PromotionPrice,
                    IncludedVat = product.IncludedVat,
                    Quantity = product.Quantity,
                    CategoryId = product.CategoryId,
                    Detail = product.Detail,
                    Warranty = product.Warranty,
                    ModifiedBy = product.ModifiedBy,
                    ModifiedDate = product.ModifiedDate,
                    MetalKeywords = product.MetalKeywords,
                    MetaDescriptions = product.MetaDescriptions,
                    Status = product.Status,
                    TopHot = product.TopHot,
                    ViewCount = product.ViewCount
                };
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        
        private string UploadFile(ProductViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "product_imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }private string UploadFile2(ProductViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "product_imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code,
                MetaTile = product.MetaTile,
                Descriptions = product.Descriptions,
                ExistingImage = product.Image,
                Price = product.Price,
                PromotionPrice = product.PromotionPrice,
                IncludedVat = product.IncludedVat,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                Detail = product.Detail,
                Warranty = product.Warranty,
                ModifiedBy = product.ModifiedBy,
                ModifiedDate = product.ModifiedDate,
                MetalKeywords = product.MetalKeywords,
                MetaDescriptions = product.MetaDescriptions,
                Status = product.Status,
                TopHot = product.TopHot,
                ViewCount = product.ViewCount
            };
            return View(productModel);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Code,MetaTile,Descriptions,Image,MoreImages,Price,PromotionPrice,IncludedVat,Quantity,CategoryId,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetalKeywords,MetaDescriptions,Status,TopHot,ViewCount", "ExistingImage")] ProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = await _context.Product.FindAsync(model.Id);

                product.Id = model.Id;
                product.Name = model.Name;
                product.Code = model.Code;
                product.MetaTile = model.MetaTile;
                product.Descriptions = model.Descriptions;
    
                //product.MoreImages = stringFileName2;
                product.Price = model.Price;
                product.PromotionPrice = model.PromotionPrice;
                product.IncludedVat = model.IncludedVat;
                product.Quantity = model.Quantity;
                product.CategoryId = model.CategoryId;
                product.Detail = model.Detail;
                product.Warranty = model.Warranty;
                product.ModifiedBy = model.ModifiedBy;
                product.ModifiedDate = model.ModifiedDate;
                product.MetalKeywords = model.MetalKeywords;
                product.MetaDescriptions = model.MetaDescriptions;
                product.Status = model.Status;
                product.TopHot = model.TopHot;
                product.ViewCount = model.ViewCount;

                if (model.Image != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "product_imgs", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    product.Image = UploadFile(model);
                }

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var product = await _context.Product.FindAsync(id);
            if(product.Image != null)
            {
                var currentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\product_imgs", product.Image);
                if (await _context.SaveChangesAsync() > 0)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
            }
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var product = await _context.Product
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //return View(product);
        }

        // POST: Admin/Product/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var product = await _context.Product.FindAsync(id);
        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
