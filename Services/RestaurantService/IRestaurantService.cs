using RestaurantTimBaig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Services.RestaurantService
{
    public interface IRestaurantService
    {
        /// <summary>
        /// Вывод списка ресторанов
        /// </summary>
        /// <returns></returns>
        Task<List<Restaurant>> GetAllRestaurants();

        /// <summary>
        /// Вывод ресторана по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Restaurant> GetRestaurantById(int id);

        /// <summary>
        /// Добавление нового ресторана
        /// </summary>
        /// <param name="newRest"></param>
        /// <returns></returns>
        Task<List<Restaurant>> AddRestaurant(Restaurant newRest);



    }
}
