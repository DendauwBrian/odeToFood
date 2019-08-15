using System.Collections.Generic;
using odeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace odeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly odeToFoodDbContext dbContext;

        public SqlRestaurantData(odeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                dbContext.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return dbContext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in dbContext.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // Give you an object that contains info that is already in there
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
