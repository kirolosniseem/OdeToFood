using OdeToFoodBusiness;
using System;
using System.Collections.Generic;

namespace OdeToFoodData
{
    public interface IRestaurantRepository
    {
        public List<Restaurant> GetAllRestaurants();
        public List<Restaurant> GetRestaurantsByName(string name);
        public Restaurant GetRestaurantsById(int id);

        public Restaurant EditRestaurant(Restaurant rest);
        public Restaurant AddRestaurant(Restaurant rest);
        public bool DeleteRestaurant(int id);

        public int CommitChanges();


    }
}
