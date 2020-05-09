using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Request
    {
        public DateTime DateRequest { get; set; }
        public bool State { get; set; }
        public decimal AssignedPoints { get; set; }
        public decimal EstimatedPoints { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Points()
        {

        }
    }
}
