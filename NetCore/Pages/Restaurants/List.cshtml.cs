using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCore.Core;
using NetCore.Data;
using System.Collections.Generic;

namespace NetCore.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public int age { get; set; }
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData,ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogError("Howa Dah El ListModel Ya Saadaaaa  !!!!!!!!!!");
            logger.LogError("Howa be3eeno Ya Saadaaaa  !!!!!!!!!!");
            Restaurants = restaurantData.GetByName(SearchTerm);
        }
    }
}