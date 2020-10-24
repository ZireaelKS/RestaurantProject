using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model.Common
{
    public class Restaurant : Entity
    {
        public string RestName { get; set; }

        public string RestAddress { get; set; }

        public string RestPhone { get; set; }

    }
}
