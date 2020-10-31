using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Столы в ресторане"
    /// </summary>
    public class TableRestaurant
    {
        /// <summary>
        /// ID ресторана
        /// </summary>
        public int IDRestTable { get; set; }

        /// <summary>
        /// Номер стола
        /// </summary>
        public int NumberTable { get; set; }

        /// <summary>
        /// Статус стола
        /// </summary>
        public bool Status { get; set; }
    }
}
