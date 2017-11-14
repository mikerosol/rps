using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Interfaces;
using Api.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers;
using Api.Code;
using Newtonsoft.Json;

namespace ApiUnitTests
{
    [TestClass]
    public class InsurancePolicy
    {
        private IInsurancePolicyRepository _insurancePolicyRepository;
        private InsurancePolicyController _controller;

        InsurancePolicy()
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
                PolicyNumber = 1,
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
                    RiskConstruction = Api.Models.Home.RiskContructionEnum.SingleWideManufacturedHome,
                    RiskYearBuilt = 2000,
                    Address = "",
                    City = "",
                    State = Api.Models.Location.StateEnum.PA,
                    ZipCode = ""
                }
            };
            var expected = new Microsoft.AspNetCore.Mvc.OkResult();

            //Act
            var actual = _controller.Post(insurancePolicy);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }
    }
}
