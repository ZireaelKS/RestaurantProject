using RestaurantTimBaig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private static List<Restaurant> restaurant = new List<Restaurant>
        {
            new Restaurant(),
            new Restaurant {IdRest = 2, NameRest = "Liza"}
        };

        public async Task<List<Restaurant>> AddRestaurant(Restaurant newRest)
        {
            restaurant.Add(newRest);
            return restaurant;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return restaurant;
        }

        public async Task<Restaurant> GetRestaurantById(int idRest)
        {
            return restaurant.FirstOrDefault(c => c.IdRest == idRest);
        }
    }
}
