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
    public class DeleteModel : PageModel
    {
        IRestaurantRepository irestaurantRepository;

        public Restaurant restaurant { get; set; }

        public DeleteModel(IRestaurantRepository _irestaurantRepository)
        {
            irestaurantRepository = _irestaurantRepository;
        }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = irestaurantRepository.GetRestaurantsById(restaurantId);
            if (restaurant != null)
                return Page();
            else
                return RedirectToPage("NotFound");
        }

        public IActionResult OnPost(int restaurantId)
        {
            var deleted = irestaurantRepository.DeleteRestaurant(restaurantId);
            if (deleted)
                return RedirectToPage("List");
            else
                return RedirectToPage("NotFound");
        }
    }
}
