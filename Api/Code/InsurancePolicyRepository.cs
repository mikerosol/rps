using Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Code
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private static List<Models.InsurancePolicy> insurancePolicies = new List<Models.InsurancePolicy>();

        public InsurancePolicyRepository (){
            #region INSURANCE POLICY 1
            insurancePolicies.Add(new Models.InsurancePolicy()
            {
                PolicyId = 1,
                PolicyNumber = 12345,
                PolicyEffectiveDate = new DateTime(2017,1,1),
                PolicyExpirationDate = new DateTime(2017, 12, 31),
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
                    Address = "123 Main Street",
                    City = "Macungie",
                    State = Models.Location.StateEnum.PA,
                    ZipCode = "12345"
                }
            });
            #endregion

            #region INSURANCE POLICY 2
            insurancePolicies.Add(new Models.InsurancePolicy()
            {
                PolicyId = 2,
                PolicyNumber = 12346,
                PolicyEffectiveDate = new DateTime(2017, 6, 1),
                PolicyExpirationDate = new DateTime(2017, 12, 31),
                PrimaryInsuredPerson = new Models.Person()
                {
                    FirstName = "Rick",
                    LastName = "Kenny",
                    Address = "50 Division Ave",
                    City = "Garfield",
                    State = Models.Location.StateEnum.NJ,
                    ZipCode = "23456"

                },
                RiskHome = new Models.Home()
                {
                    RiskConstruction = Models.Home.RiskContructionEnum.DoubleWideManufacturedHome,
                    RiskYearBuilt = 1998,
                    Address = "50 Division Ave",
                    City = "Garfield",
                    State = Models.Location.StateEnum.NJ,
                    ZipCode = "23456"
                }
            });
            #endregion

            #region INSURANCE POLICY 3
            insurancePolicies.Add(new Models.InsurancePolicy()
            {
                PolicyId = 3,
                PolicyNumber = 12347,
                PolicyEffectiveDate = new DateTime(2017, 3, 1),
                PolicyExpirationDate = new DateTime(2018, 3, 31),
                PrimaryInsuredPerson = new Models.Person()
                {
                    FirstName = "Alex",
                    LastName = "Benny",
                    Address = "72 Goldenrod Drive",
                    City = "Wicker",
                    State = Models.Location.StateEnum.SC,
                    ZipCode = "34567"

                },
                RiskHome = new Models.Home()
                {
                    RiskConstruction = Models.Home.RiskContructionEnum.ModularHome,
                    RiskYearBuilt = 1980,
                    Address = "892 Banta Ave",
                    City = "Wicker",
                    State = Models.Location.StateEnum.SC,
                    ZipCode = "34567"
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