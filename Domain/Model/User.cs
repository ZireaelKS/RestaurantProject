using Microsoft.AspNetCore.Identity;
using RestaurantTimBaig.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.Model
{
    public class User : IdentityUser<int>
    {
        public Restaurant Restaurant { get; set; }

    }
}
