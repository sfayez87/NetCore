using Microsoft.EntityFrameworkCore;
using NetCore.Core;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantsDbContext restaurantsDb;

        public SqlRestaurantData(RestaurantsDbContext restaurantsDb)
        {
            this.restaurantsDb = restaurantsDb;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurantsDb.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return restaurantsDb.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant !=null)
            {
                restaurantsDb.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurantsDb.Restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurantsDb.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return from r in restaurantsDb.Restaurants
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public int GetRestaurantsCount()
        {
            return restaurantsDb.Restaurants.Count();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = restaurantsDb.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
