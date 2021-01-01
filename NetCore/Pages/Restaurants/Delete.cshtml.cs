using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCore.Core;
using NetCore.Data;

namespace NetCore.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant ==null)
            {
                return RedirectToPage("./NotFound");
            }
                return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();
            if (Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{Restaurant.Name} is Deleted";
            return RedirectToPage("./List");
        }
    }
}