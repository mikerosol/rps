using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InsurancePolicyController : Controller
    {
        private List<Models.InsurancePolicy> _insurancePolicies;

        public InsurancePolicyController()
        {            
            InitializeData();
        }

        private void InitializeData()
        {
            _insurancePolicies = new List<Models.InsurancePolicy>();

            #region INSURANCE POLICY 1
            _insurancePolicies.Add(new Models.InsurancePolicy()
            {
                PolicyNumber = 1,
                PolicyEffectiveDate = DateTime.Now,
                PolicyExpirationDate = DateTime.Now,
                PrimaryInsuredPerson = new Models.Person()
                {
                    FirstName = "Alison",
                    LastName = "Manning",
                    Residence = new Models.Location()
                    {
                        Address = "123 Main Street",
                        City = "Macungie",
                        State = Models.Location.StateEnum.PA,
                        ZipCode = "12345"
                    }
                },
                RiskHome = new Models.Home()
                {
                    Location = new Models.Location()
                    {
                        Address = "",
                        City = "",
                        State = Models.Location.StateEnum.PA,
                        ZipCode = ""
                    },
                    RiskConstruction = Models.Home.RiskContructionEnum.SingleWideManufacturedHome,
                    RiskYearBuilt = 2000
                }
            });
            #endregion
        }
        
        [HttpGet]
        public IEnumerable<Models.InsurancePolicy> Get()
        {
            return _insurancePolicies;
        }
    }
}