using System;
using System.Collections.Generic;
using System.Linq;
using odeToFood.Core;

namespace odeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id=2, Name="Cinnamon Club", Location="London", Cuisine=CuisineType.Indian},
                new Restaurant {Id=3, Name="La Costa", Location="California", Cuisine=CuisineType.Mexican},
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) orderby r.Name select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id.Equals(id));
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id.Equals(updatedRestaurant.Id));
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id.Equals(id));
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
