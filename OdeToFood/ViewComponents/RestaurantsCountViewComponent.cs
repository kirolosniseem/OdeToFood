using Microsoft.AspNetCore.Mvc;
using OdeToFoodData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantsCountViewComponent : ViewComponent
    {
        public IRestaurantRepository irestaurantRepository { get; }

        public RestaurantsCountViewComponent(IRestaurantRepository _irestaurantRepository)
        {
            irestaurantRepository = _irestaurantRepository;
        }

        public IViewComponentResult Invoke()
        {
           var restCount =  irestaurantRepository.GetAllRestaurants().Count();
            return View(restCount);
        }
    }
}
