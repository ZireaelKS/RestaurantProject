using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Models
{
    public class RestaurantViewModel
    {
        /// <summary>
        /// Название ресторана
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Местонахождение ресторана
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Описание ресторана
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Эл. почта ресторана
        /// </summary>
        public string Email { get; set; }
    }
}
