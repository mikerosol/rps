using System;
using System.ComponentModel.DataAnnotations;

namespace Objects
{    
    public class InsurancePolicy
    {                      
        public int PolicyId { get; set; }

        //[Required]
        public int PolicyNumber { get; set; }

        //[Required]
        public DateTime PolicyEffectiveDate { get; set; }

        //[Required]
        public DateTime PolicyExpirationDate { get; set; }

        public Objects.Person PrimaryInsuredPerson { get; set; }
        public Objects.Home RiskHome { get; set; }
    }
}