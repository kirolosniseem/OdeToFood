using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFoodBusiness;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        IRestaurantRepository irestaurantRepository;
        private readonly ILogger<DeleteModel> ilogger;

        public Restaurant restaurant { get; set; }

        public DeleteModel(IRestaurantRepository _irestaurantRepository, ILogger<DeleteModel> _ilogger)
        {
            irestaurantRepository = _irestaurantRepository;
            ilogger = _ilogger;
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
            {
                ilogger.LogWarning("Deleting a restaurant");
                return RedirectToPage("List");
            }
            else
            {
                ilogger.LogError("Restaurant trying to delete is not found");
                return RedirectToPage("NotFound");
            }
        }
    }
}
