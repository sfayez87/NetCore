using NetCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="primos pizza",Location="mostafa elna7as",Cuisine=CuisineType.Italian},
                new Restaurant{Id=2,Name="jhgjh",Location="haha ja",Cuisine=CuisineType.Mexican},
                new Restaurant{Id=3,Name="nbvnv",Location="nnnklll",Cuisine=CuisineType.Indian}
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(restaurants => restaurants.Id == id);
            if (restaurant !=null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public int GetRestaurantsCount()
        {
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant !=null)
            {
            restaurant.Id = updatedRestaurant.Id;
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
