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
        public string NameRest { get; set; }

        /// <summary>
        /// Местонахождение ресторана
        /// </summary>
        public string AddressRest { get; set; }

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string PhoneRest { get; set; }
    }
}
