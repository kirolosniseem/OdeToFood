using OdeToFoodBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
    public class RestaurantInMemoryRepo : IRestaurantRepository
    {
        public List<Restaurant> restaurants { get; set; }

        public RestaurantInMemoryRepo()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){Id = 1, Name = "Oriental Restaurant", Location = "Egypt", RestaurantType = RestaurantTypeEnum.Oriental},
                new Restaurant(){Id = 2, Name = "Mexico", Location = "Mexico", RestaurantType = RestaurantTypeEnum.Mexican},
                new Restaurant(){Id = 3, Name = "Italiano", Location = "Rome", RestaurantType = RestaurantTypeEnum.Italian}
            };
        }
        public List<Restaurant> GetAllRestaurants()
        {
            return restaurants.OrderBy(r => r.Name).ToList();
        }

        public List<Restaurant> GetRestaurantsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = "";
            return restaurants.Where(r=>r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Name).ToList();
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public Restaurant EditRestaurant(Restaurant rest)
        {
            var res = restaurants.SingleOrDefault(r => r.Id == rest.Id);
            if(res != null)
            {
                res.Name = rest.Name;
                res.Location = rest.Location;
                res.RestaurantType = rest.RestaurantType;
                CommitChanges();
            }
            return res;
        }

        public Restaurant AddRestaurant(Restaurant rest)
        {
            if (rest != null)
            {
                int newId = restaurants.Max(r => r.Id) +1;
                rest.Id = newId;
                restaurants.Add(rest);
                CommitChanges();
            }
            return rest;
        }

        public int CommitChanges()
        {
            return 0;
        }

        public bool DeleteRestaurant(int id)
        {
            var rest = restaurants.Where(r => r.Id == id).FirstOrDefault();
            if(rest != null)
            {
                restaurants.Remove(rest);
                CommitChanges();
                return true;
            }
            return false;
        }
    }
}
