using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoodBusiness;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IConfiguration config { get; }
        public IRestaurantRepository restaurantRepository { get; }
        public string message { get; set; }
        public List<Restaurant> restaurants { get; set; }

        [BindProperty (SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration _config, IRestaurantRepository _restaurantRepository)
        {
            config = _config;
            restaurantRepository = _restaurantRepository;
        }
        public void OnGet()
        {
            message = config["WelcomeMessage"];

            //var restName = HttpContext.Request.Headers["searchterm"];
            var restName = SearchTerm;
            restaurants = restaurantRepository.GetRestaurantsByName(restName);
        }
    }
}
