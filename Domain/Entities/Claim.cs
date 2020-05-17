using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Claim : Entity<int>
    {
        public string Description { get; set; }
        public string Answer { get; set; }
        public DateTime ClaimDate { get; set; }
        public Request Request { get; set; }
        
        public void RequestClaim(string description)
        {
            //validar fecha reclamo
            Description = description;
            ClaimDate = DateTime.Now;
        }

        public void AnswerClaim(string answer)
        {
            Answer = answer;  
        }
    }
}
