using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Model.Common
{
    /// <summary>
    /// Интерфейс модели сущности предметной области
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Создание экземпляра модели сущности предметной сущности
        /// </summary>
        protected Entity()
        { }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public virtual long Id { get; set; }
    }
}
