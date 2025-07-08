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
    }
}
