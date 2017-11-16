using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{    
    public class InsurancePolicy
    {                      
        public int PolicyId { get; set; }

        //[Required]
        [Display(Name = "Policy Number")]
        public int PolicyNumber { get; set; }

        //[Required]
        [Display(Name = "Policy Effective Date")]
        public DateTime PolicyEffectiveDate { get; set; }

        //[Required]
        [Display(Name = "Policy Expiration Date")]
        public DateTime PolicyExpirationDate { get; set; }

        public Models.Person PrimaryInsuredPerson { get; set; }
        public Models.Home RiskHome { get; set; }
    }
}