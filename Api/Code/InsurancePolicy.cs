using Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using System;

namespace Api.Code
{
    public class InsurancePolicy : IInsurancePolicyRepository
    {
        private static List<Models.InsurancePolicy> insurancePolicies = new List<Models.InsurancePolicy>();
        
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