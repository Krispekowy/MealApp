using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealApp.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public AddModel(
            IProductRepository productRepository,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }
        [BindProperty]
        public ProductDTO ProductDTO { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                return RedirectToPage("Error");
            }
            string uniqueFileName = null;
            if (ProductDTO.Photo != null)
            {
                uniqueFileName = UploadPhoto();
            }
            var product = mapper.Map<Product>(ProductDTO);
            product.PhotoPath = uniqueFileName;
            productRepository.AddProduct(product);
            return RedirectToPage("Index");
        }

        private string UploadPhoto()
        {
            string uniqueFileName;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + ProductDTO.Photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            ProductDTO.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
