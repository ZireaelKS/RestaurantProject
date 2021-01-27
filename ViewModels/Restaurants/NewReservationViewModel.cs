using RestaurantTimBaig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.ViewModels.Restaurants
{
    public class NewReservationViewModel
    {
        /// <summary>
        /// Id ресторана
        /// </summary>
        public long IdRestaurant { get; set; }

        /// <summary>
        /// Номер заказанного стола
        /// </summary>
        public long NumberTableRestaurant { get; set; }

        /// <summary>
        /// Время бронирования
        /// </summary>
        public DateTime TimeReservation { get; set; } = DateTime.Now;
    }
}
