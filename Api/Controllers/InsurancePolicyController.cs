using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InsurancePolicyController : Controller
    {
        private IInsurancePolicyRepository _insurancePolicyRepository;

        public InsurancePolicyController(Interfaces.IInsurancePolicyRepository insurancePolicyRepositor)
        {
            _insurancePolicyRepository = insurancePolicyRepositor;
        }
        
        [HttpGet]
        public IEnumerable<Models.InsurancePolicy> Get()
        {
            return _insurancePolicyRepository.Get();
        }
    }
}