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

namespace MealApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteModel(
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public ProductDTO ProductDTO { get; set; }
        public IActionResult OnGet(int id)
        {
            var product = productRepository.GetProduct(id);
            ProductDTO = mapper.Map<ProductDTO>(product);
            if (ProductDTO == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Product product = productRepository.DeleteProduct(ProductDTO.Id);
            if (product==null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Products/Index");
        }
    }
}
