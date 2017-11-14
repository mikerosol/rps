using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
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

        public Models.Person PrimaryInsuredPerson { get; set; }
        public Models.Home RiskHome { get; set; }
    }
}