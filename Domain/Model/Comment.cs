using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model
{
    /// <summary>
    /// Модель данных "Комментарий"
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Id ресторана
        /// </summary>
        public int IDRest { get; set; }

        /// <summary>
        /// Id посетителя
        /// </summary>
        public int IDVisitor { get; set; }

        /// <summary>
        /// Дата создания комментария
        /// </summary>
        public DateTime DateComment { get; set; }

        /// <summary>
        /// Оценка посетителя
        /// </summary>
        public int Point  { get; set; }

        /// <summary>
        /// Содержиме комментария
        /// </summary>
        public string DataComment { get; set; }
    }
}
