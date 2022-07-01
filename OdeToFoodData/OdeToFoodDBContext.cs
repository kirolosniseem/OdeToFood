using Microsoft.EntityFrameworkCore;
using OdeToFoodBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodData
{
    public class OdeToFoodDBContext : DbContext
    {
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options)
            :base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
