using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class User
    {
        public User()
        {

        }

        public Guid UserId { get; set; }
        public Guid InfrastructureId { get; set; }
    }
}