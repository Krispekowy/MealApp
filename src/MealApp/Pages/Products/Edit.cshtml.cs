using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public EditModel(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
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
            var product = mapper.Map<Product>(ProductDTO);
            productRepository.UpdateProduct(product);
            return RedirectToPage("Index");
        }
    }
}
