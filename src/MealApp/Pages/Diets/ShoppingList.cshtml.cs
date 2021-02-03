using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using ClosedXML.Excel;
using IronXL;
using MealApp.Models.Models;
using MealApp.Models.Static;
using MealApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealApp.Pages.Diets
{
    public class ShoppingListModel : PageModel
    {
        private readonly IDietRepository dietRepository;
        private readonly IDayDietRepository dayDietRepository;
        private readonly IShoppingListRepository shoppingListRepository;
        private readonly IMapper mapper;

        public ShoppingListModel(
            IDietRepository dietRepository,
            IDayDietRepository dayDietRepository,
            IShoppingListRepository shoppingListRepository,
            IMapper mapper)
        {
            this.dietRepository = dietRepository;
            this.dayDietRepository = dayDietRepository;
            this.shoppingListRepository = shoppingListRepository;
            this.mapper = mapper;
        }
        public DietDTO DietDTO { get; set; }
        [BindProperty]
        public List<ShoppingDayDTO> Days { get; set; }

        public IActionResult OnGet(int dietId)
        {
            var diet = dietRepository.GetDiet(dietId);
            DietDTO = mapper.Map<DietDTO>(diet);
            return Page();
        }

        public IActionResult OnPost()
        {
            var dayIds = new List<int>();
            foreach (var day in Days)
            {
                dayIds.Add(day.DayId);
            }
            var shoppingList = shoppingListRepository.GetShoppingList(Days);
            GenerateXLSX(shoppingList);

            return RedirectToPage("/Diets/Index");

        }

        private static void GenerateXLSX(List<ShoppingListDTO> shoppingList)
        {
            WorkBook xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsxWorkbook.Metadata.Author = "MealApp";
            WorkSheet xlsxSheet = xlsxWorkbook.CreateWorkSheet("Lista zakupów");

            var row = 1;
            foreach (var cat in shoppingList)
            {
                xlsxSheet["A" + row].Value = cat.Category;
                xlsxSheet["A" + row].Style.SetBackgroundColor("#428D65");
                foreach (var pro in cat.Products)
                {
                    row++;
                    xlsxSheet["A" + row].Value = pro.Product;
                    xlsxSheet["B" + row].Value = pro.Quantity;
                }
                row++;
            }
            xlsxWorkbook.SaveAs("MojaListaZakupow.xlsx");
            xlsxWorkbook.Close();
        }
    }
}
