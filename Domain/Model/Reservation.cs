using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Бронирование"
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Номер бронирования
        /// </summary>
        public int NumberReserv { get; set; }

        /// <summary>
        /// Id ресторана
        /// </summary>
        public int IDRestReserv { get; set; }

        /// <summary>
        /// Id посетителя
        /// </summary>
        public int IDVisitorReserv { get; set; }

        /// <summary>
        /// Номер заказанного стола
        /// </summary>
        public int TableNumber { get; set; }

        /// <summary>
        /// Время бронирования
        /// </summary>
        public DateTime TimeReserv { get; set; }

        /// <summary>
        /// Дата создания брони
        /// </summary>
        public DateTime DateReserv { get; set; }
    }
}
