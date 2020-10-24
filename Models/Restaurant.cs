using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Models
{
    public class Restaurant
    {
        /// <summary>
        /// Идентификатор ресторана
        /// </summary>
        public int IdRest { get; set; } = 1;

        /// <summary>
        /// Название ресторана
        /// </summary>
        public string NameRest { get; set; } = "Ksenia";

        /// <summary>
        /// Местонахождение ресторана
        /// </summary>
        public string AddressRest { get; set; } = "Yablochkova";

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string PhoneRest { get; set; } = "89684521364";
    }
}
