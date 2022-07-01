using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodBusiness;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public Restaurant restaurant { get; set; }
        public IRestaurantRepository iRestaurantRepository { get; }

        public DetailsModel(IRestaurantRepository _iRestaurantRepository)
        {
            iRestaurantRepository = _iRestaurantRepository;
        }

        //public void OnGet(int restaurantId)
        //{
        //    restaurant = new Restaurant();
        //    restaurant.Id = restaurantId;

        //    var res = iRestaurantRepository.GetRestaurantsById(restaurantId);
        //    if(res != null)
        //    {
        //        restaurant.Name = res.Name;
        //        restaurant.Location = res.Location;
        //        restaurant.RestaurantType = res.RestaurantType;
        //    }
        //}

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = iRestaurantRepository.GetRestaurantsById(restaurantId);
            if (restaurant != null)
                return Page();
            else
                return RedirectToPage("./NotFound");


        }
    }
}
