using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IInsurancePolicyRepository
    {
        List<Models.InsurancePolicy> Get(int? insurancePolicyId = null);
        Models.InsurancePolicy Save(Models.InsurancePolicy insurancePolicy);
        void Delete(int insurancePolicyId);
    }
}
