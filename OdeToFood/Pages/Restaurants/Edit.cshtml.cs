using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodBusiness;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository iRestaurantRepository;
        private readonly IHtmlHelper iHtmlHelper;

        [BindProperty(SupportsGet = true)]
        public Restaurant restaurant { get; set; }

        public IEnumerable<SelectListItem> restTypeItems { get; set; }

        public EditModel(IRestaurantRepository _iRestaurantRepository, IHtmlHelper _iHtmlHelper)
        {
            iRestaurantRepository = _iRestaurantRepository;
            iHtmlHelper = _iHtmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restTypeItems = iHtmlHelper.GetEnumSelectList<RestaurantTypeEnum>();

            restaurant = iRestaurantRepository.GetRestaurantsById(restaurantId);

            if (restaurant == null)
                restaurant = new Restaurant();

            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                restTypeItems = iHtmlHelper.GetEnumSelectList<RestaurantTypeEnum>();
                return Page();
            }

            if (restaurant.Id > 0)
                iRestaurantRepository.EditRestaurant(restaurant);
            else
                iRestaurantRepository.AddRestaurant(restaurant);

            TempData["Message"] = "Restaurant Saved";
            return RedirectToPage("./Details", new { restaurantId = restaurant.Id });
        }
    }
}
