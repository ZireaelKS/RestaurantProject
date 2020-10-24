using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTimBaig.Models;
using RestaurantTimBaig.Services.RestaurantService;

namespace RestaurantTimBaig.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Вывод списка ресторанов
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _restaurantService.GetAllRestaurants());
        }

        /// <summary>
        /// Вывод ресторана по id
        /// </summary>
        /// <param name="idRest"></param>
        /// <returns></returns>
        [HttpGet("{idRest}")]
        public async Task<IActionResult> GetRest(int idRest)
        {
            return Ok(await _restaurantService.GetRestaurantById(idRest));
        }

        /// <summary>
        /// Добавление нового ресторана
        /// </summary>
        /// <param name="newRest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRest(Restaurant newRest)
        {
            return Ok(await _restaurantService.AddRestaurant(newRest));
        }
    }
}
