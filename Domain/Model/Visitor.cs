using RestaurantTimBaig.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Посетитель"
    /// </summary>
    public class Visitor : Entity
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Прозвище
        /// </summary>
        public string Nickname { get; set; }
    }
}
