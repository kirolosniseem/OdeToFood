using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFoodBusiness
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Location { get; set; }
        public RestaurantTypeEnum RestaurantType { get; set; }
    }

    public enum RestaurantTypeEnum
    {
        Oriental = 1,
        Mexican = 2, 
        Italian = 3
    }
}
