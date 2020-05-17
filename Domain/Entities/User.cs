using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User: Entity<int>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        
    }
}
