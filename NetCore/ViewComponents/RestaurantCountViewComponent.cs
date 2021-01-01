using Microsoft.AspNetCore.Mvc;
using NetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
           var count= restaurantData.GetRestaurantsCount();
            return View(count);
        }
    }
}
