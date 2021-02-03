using MealApp.Models.Models;
using System.Collections.Generic;

namespace MealApp.Services
{
    public interface IShoppingListRepository
    {
        List<ShoppingListDTO> GetShoppingList(List<ShoppingDayDTO> days);
    }
}