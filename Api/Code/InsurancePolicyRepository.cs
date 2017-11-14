using Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using System;

namespace Api.Code
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private static List<Models.InsurancePolicy> insurancePolicies = new List<Models.InsurancePolicy>();

        public InsurancePolicyRepository (){
            #region INSURANCE POLICY 1
            insurancePolicies.Add(new Models.InsurancePolicy()
            {
                PolicyNumber = 1,
                PolicyEffectiveDate = DateTime.Now,
                PolicyExpirationDate = DateTime.Now,
                PrimaryInsuredPerson = new Models.Person()
                {
                    FirstName = "Alison",
                    LastName = "Manning",
                    Address = "123 Main Street",
                    City = "Macungie",
                    State = Models.Location.StateEnum.PA,
                    ZipCode = "12345"
                    
                },
                RiskHome = new Models.Home()
                {
                    RiskConstruction = Models.Home.RiskContructionEnum.SingleWideManufacturedHome,
                    RiskYearBuilt = 2000,
                    Address = "",
                    City = "",
                    State = Models.Location.StateEnum.PA,
                    ZipCode = ""                                       
                }
            });
            #endregion
        }

        public List<Models.InsurancePolicy> Get(int? insurancePolicyId = null)
        {
            return insurancePolicyId == null ?
                insurancePolicies :
                insurancePolicies.Where(i => i.PolicyId == insurancePolicyId).ToList();
        }
        public Models.InsurancePolicy Save(Models.InsurancePolicy insurancePolicy)
        {
            var existingInsurancePolicy = insurancePolicies
                .SingleOrDefault(i => i.PolicyId == insurancePolicy.PolicyId);

            if (existingInsurancePolicy == null)
            {
                insurancePolicy.PolicyId = insurancePolicy.PolicyId > 0 ?
                    insurancePolicy.PolicyId :
                    insurancePolicies.Max(i => i.PolicyId) + 1;

                insurancePolicies.Add(insurancePolicy);
            }
            else
            {
                throw new System.NotImplementedException("Currently updating an insurance policy is not implemented.");
            }

            return insurancePolicy;
        }
        public void Delete(int insurancePolicyId)
        {
            insurancePolicies.RemoveAll(i => i.PolicyId == insurancePolicyId);
        }
    }
}