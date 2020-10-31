using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model.Common
{
    /// <summary>
    /// Модель данных "Ресторан"
    /// </summary>
    public class Restaurant : Entity
    {
        /// <summary>
        /// Название ресторана
        /// </summary>
        public string RestName { get; set; }

        /// <summary>
        /// Адрес ресторана
        /// </summary>
        public string RestAddress { get; set; }

        /// <summary>
        /// Номер телефона ресторана
        /// </summary>
        public string RestPhone { get; set; }

    }
}
