﻿using System;
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
        public IEnumerable<Models.InsurancePolicy> Get(int? insurancePolicyId)
        {
            return _insurancePolicyRepository.Get(insurancePolicyId);
        }        

        [HttpPost]
        public Models.InsurancePolicy Post([FromBody]Models.InsurancePolicy insurancePolicy)
        {
            return _insurancePolicyRepository.Save(insurancePolicy);
        }

        [HttpDelete]
        public bool Delete(int insurancePolicyId)
        {
            _insurancePolicyRepository.Delete(insurancePolicyId);
            return true;
        }
    }
}