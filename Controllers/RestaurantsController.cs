using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantTimBaig.Domain.DB;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Domain.Model.Common;
using RestaurantTimBaig.Models;
using RestaurantTimBaig.Security.Extensions;
using RestaurantTimBaig.ViewModels.Restaurants;

namespace RestaurantTimBaig.Controllers
{
    [Route("{controller}")]
    public class RestaurantsController : Controller
    {

        private readonly RestaurantDBContext _restaurantDBContext;
        Random rnd = new Random();

        public RestaurantsController(RestaurantDBContext restaurantDBContext)
        {
            _restaurantDBContext = restaurantDBContext ?? throw new ArgumentNullException(nameof(restaurantDBContext));
        }

        /// <summary>
        /// Вывод списка ресторанов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListRestaurants()
        {
            var restaurants = _restaurantDBContext.Restaurants
                .Select(x => new RestaurantViewModel
                {
                    Id = x.Id,
                    Name = x.RestaurantName,
                    Address = x.RestaurantAddress
                }).OrderByDescending(x => x.Name);
            return View(restaurants.ToList());
        }

        /// <summary>
        /// Вывод ресторана по id
        /// </summary>
        /// <param name="idRestaurant"></param>
        /// <returns></returns>
        [HttpGet("RestaurantPage/{idRestaurant}")]
        public IActionResult RestaurantPage(long idRestaurant)
        {
            var restaurants = _restaurantDBContext.Restaurants.Include(r => r.Dishes)
                .Include(x => x.TableRestaurants)
                .Include(r => r.Comments)
                .ThenInclude(x => x.Employee)
                .Where(r => r.Id == idRestaurant)
                .Select(r => new RestaurantViewModel
                {
                    Id = r.Id,
                    Name = r.RestaurantName,
                    Address = r.RestaurantAddress,
                    Phone = r.RestaurantPhone,
                    Description = r.RestaurantDescription,
                    Email = r.RestaurantEmail,
                    Dishes = r.Dishes,
                    TableRestaurants = r.TableRestaurants,
                    Comments = r.Comments,
                }).FirstOrDefault();
            return View(restaurants);
        }

        /// <summary>
        /// Добавление оценки ресторана пользователем
        /// </summary>
        [Authorize]
        [HttpGet("AddComment/{idRestaurant}")]
        public IActionResult AddComment(long idRestaurant)
        {
            ViewBag.id = idRestaurant;
            return View();
        }

        [Authorize]
        [HttpPost("AddCommentRestaurant")]
        [ValidateAntiForgeryToken]
        public IActionResult AddCommentRestaurant(NewCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            Restaurant restaurant = null;

            foreach (Restaurant r in _restaurantDBContext.Restaurants)
            {
                if (r.Id == model.IdRestaurant)
                {
                    restaurant = r;
                }
            }

            var comment = new Comment
            {
                Restaurant = restaurant,
                Employee = user.Employee,
                DateComment = DateTime.Now,
                Point = model.Point,
                DataComment = model.DataComment,
            };

            _restaurantDBContext.Comments.Add(comment);
            _restaurantDBContext.SaveChanges();

            return Redirect("/Restaurants/RestaurantPage/" + restaurant.Id.ToString());
        }

        /// <summary>
        /// Бронирование ресторана пользователем
        /// </summary>
        [Authorize]
        [HttpGet("AddReserve/{idRestaurant}")]
        public IActionResult AddReserve(long idRestaurant)
        {
            ViewBag.id = idRestaurant;
            return View();
        }

        [Authorize]
        [HttpPost("AddReservationRestaurant")]
        [ValidateAntiForgeryToken]
        public IActionResult AddReservationRestaurant(NewReservationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            Restaurant restaurant = null;
            TableRestaurant tableRestaurant = null;
            
            foreach (Restaurant r in _restaurantDBContext.Restaurants.Include(x => x.TableRestaurants))
            {
                if (r.Id == model.IdRestaurant)
                {
                    restaurant = r;
                    foreach (TableRestaurant t in r.TableRestaurants)
                    {
                        if (t.NumberTable == model.NumberTableRestaurant)
                        {
                            tableRestaurant = t;
                        }
                    }
                }
            }

            var reserve = new Reservation
            {
                NumberReservation = rnd.Next(100000, 999999),
                Restaurant = restaurant,
                Employee = user.Employee,
                TableRestaurant = tableRestaurant,
                TimeReservation = model.TimeReservation,
                DateReservation = DateTime.Now,
            };

            _restaurantDBContext.Reservations.Add(reserve);
            _restaurantDBContext.SaveChanges();

            return Redirect("/Restaurants/RestaurantPage/" + restaurant.Id.ToString());
        }
    }
}
