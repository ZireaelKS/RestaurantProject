using RestaurantTimBaig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Models
{
    public class DishViewModel
    {
        /// <summary>
        /// Тип блюда
        /// </summary>
        public TypeDish Type { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        public string NameDish { get; set; }

        /// <summary>
        /// Время приготовления
        /// </summary>
        public long CookingTime { get; set; }

        /// <summary>
        /// Состав блюда
        /// </summary>
        public string Composition { get; set; }
    }
}
