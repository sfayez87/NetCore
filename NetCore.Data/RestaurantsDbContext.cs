using Microsoft.EntityFrameworkCore;
using NetCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data
{
    public class RestaurantsDbContext:DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext>options)
            :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
