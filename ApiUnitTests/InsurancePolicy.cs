using Api.Code;
using Api.Controllers;
using Api.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace ApiUnitTests
{
    [TestClass]
    public class InsurancePolicy
    {
        private IInsurancePolicyRepository _insurancePolicyRepository;
        private InsurancePolicyController _controller;

        public InsurancePolicy()
        {
            _insurancePolicyRepository = new InsurancePolicyRepository();
            _controller = new InsurancePolicyController(_insurancePolicyRepository);
        }

        [TestMethod]
        public void AddInsurancePolicy_Success()
        {
            //Arrange
            var insurancePolicy = new Api.Models.InsurancePolicy()
            {
                PolicyNumber = 100,
                PolicyEffectiveDate = DateTime.Now,
                PolicyExpirationDate = DateTime.Now,
                PrimaryInsuredPerson = new Api.Models.Person()
                {
                    FirstName = "Alison",
                    LastName = "Manning",
                    Address = "123 Main Street",
                    City = "Macungie",
                    State = Api.Models.Location.StateEnum.PA,
                    ZipCode = "12345"

                },
                RiskHome = new Api.Models.Home()
                {
                    RiskConstruction = Api.Models.Home.RiskConstructionEnum.SingleWideManufacturedHome,
                    RiskYearBuilt = 2000,
                    Address = "",
                    City = "",
                    State = Api.Models.Location.StateEnum.PA,
                    ZipCode = ""
                }
            };

            //Act
            var response = _controller.Post(insurancePolicy);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(insurancePolicy), JsonConvert.SerializeObject(response));
        }

        [TestMethod]
        public void DeleteInsurancePolicy_RemovesPolicy()
        {
            // Arrange - add a policy first
            var insurancePolicy = new Api.Models.InsurancePolicy()
            {
                PolicyNumber = 200,
                PolicyEffectiveDate = DateTime.Now,
                PolicyExpirationDate = DateTime.Now,
                PrimaryInsuredPerson = new Api.Models.Person()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "1 Test Way",
                    City = "Testville",
                    State = Api.Models.Location.StateEnum.PA,
                    ZipCode = "00000"

                },
                RiskHome = new Api.Models.Home()
                {
                    RiskConstruction = Api.Models.Home.RiskContructionEnum.SingleWideManufacturedHome,
                    RiskYearBuilt = 1999,
                    Address = "",
                    City = "",
                    State = Api.Models.Location.StateEnum.PA,
                    ZipCode = ""
                }
            };

            // Add the policy using the controller
            _controller.Post(insurancePolicy);

            // Act - delete the policy
            _controller.Delete(insurancePolicy.PolicyId);

            // Assert - the repository should no longer return the policy
            var deleted = _insurancePolicyRepository.Get(insurancePolicy.PolicyId);
            Assert.AreEqual(0, deleted.Count);
        }
    }
}
