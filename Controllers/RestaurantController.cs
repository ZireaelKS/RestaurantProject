using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantTimBaig.Domain.DB;
using RestaurantTimBaig.Domain.Model.Common;
using RestaurantTimBaig.Models;

namespace RestaurantTimBaig.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly RestaurantDBContext _restaurantDBContext;

        public RestaurantController(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext ?? throw new ArgumentNullException(nameof(restaurantDBContext));
        }

        /// <summary>
        /// Вывод списка ресторанов
        /// </summary>
        /// <returns></returns>
        ///[HttpGet]
        public IActionResult Get()
        {
            var restaurants = _restaurantDBContext.Restaurants
                .Select(x => new RestaurantViewModel
                {
                    NameRest = x.RestaurantName,
                    AddressRest = x.RestaurantAddress,
                    PhoneRest = x.RestaurantPhone,
                }).OrderByDescending(x => x.NameRest);
                
            return Ok(restaurants);
        }

        /// <summary>
        /// Вывод ресторана по id (пока не юзабельно)
        /// </summary>
        /// <param name="idRest"></param>
        /// <returns></returns>
        [HttpGet("{idRest}")]
        public IActionResult GetRest(int idRest)
        {
            var restaurants = _restaurantDBContext.Restaurants
                .Select(x => new RestaurantViewModel
                {
                    NameRest = x.RestaurantName,
                    AddressRest = x.RestaurantAddress,
                    PhoneRest = x.RestaurantPhone,
                }).OrderByDescending(x => x.NameRest);

            return Ok(idRest);
        }

        /// <summary>
        /// Добавление нового ресторана
        /// </summary>
        /// <param name="newRest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRestaurant(Restaurant data)
        {
            var rest = new Restaurant
            {
                RestaurantName = data.RestaurantName,
                RestaurantAddress = data.RestaurantAddress,
                RestaurantPhone = data.RestaurantPhone
            };
            _restaurantDBContext.Restaurants.Add(rest);
            _restaurantDBContext.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление ресторана из списка
        /// </summary>
        /// <param name="id">Идентификатор ресторана</param>
        [HttpDelete("{id}/delete")]
        public IActionResult DeleteRestaurant(int id)
        {
            Restaurant rest = _restaurantDBContext.Restaurants.Find(id);
            try
            {
                _restaurantDBContext.Remove(rest);
                _restaurantDBContext.SaveChanges();
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Изменение данных ресторана (не работает, пока)
        /// </summary>
        /// <param name="rest"></param>
        /// <returns></returns>
        [HttpPost("updata")]
        public ActionResult EditBook(Restaurant rest)
        {
            _restaurantDBContext.Entry(rest).State = EntityState.Modified;
            _restaurantDBContext.SaveChanges();
            return Ok();
        }
    }
}
