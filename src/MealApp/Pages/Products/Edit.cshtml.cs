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
    public class EditModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public EditModel(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }
        [BindProperty]
        public ProductDTO ProductDTO { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IActionResult OnGet(int id)
        {
            var product = productRepository.GetProduct(id);
            var categories = categoryRepository.GetAllCategories();
            Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ProductDTO = mapper.Map<ProductDTO>(product);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (ProductDTO.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + ProductDTO.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    ProductDTO.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var product = mapper.Map<Product>(ProductDTO);
                product.PhotoPath = uniqueFileName;
                productRepository.UpdateProduct(product);
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}
