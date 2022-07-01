using OdeToFoodBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
    public class RestaurantSQLDatabaseRepo : IRestaurantRepository
    {
        public OdeToFoodDBContext dbContext { get; set; }

        public RestaurantSQLDatabaseRepo(OdeToFoodDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return dbContext.Restaurants.OrderBy(r => r.Name).ToList();
        }

        public List<Restaurant> GetRestaurantsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = "";
            return dbContext.Restaurants.Where(r=>r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Name).ToList();
        }

        public Restaurant GetRestaurantsById(int id)
        {
            //return dbContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();
            return dbContext.Restaurants.Find(id);
        }

        public Restaurant EditRestaurant(Restaurant rest)
        {
            var entity = dbContext.Restaurants.Attach(rest);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            CommitChanges();
            return rest;
        }

        public Restaurant AddRestaurant(Restaurant rest)
        {
            if (rest != null)
            {
                dbContext.Restaurants.Add(rest);
                CommitChanges();
            }
            return rest;
        }

        public int CommitChanges()
        {
            return dbContext.SaveChanges();
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantsById(id);
            if (restaurant != null)
            {
                dbContext.Restaurants.Remove(restaurant);
                CommitChanges();
                return true;
            }
            return false;
        }
    }
}
