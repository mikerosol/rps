using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    public class InsurancePolicyController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                var insurancePolicies = await api.Request<List<Api.Models.InsurancePolicy>>(HttpMethod.Get, "InsurancePolicy", "", null, null);
                return View(insurancePolicies);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            #region Generate state enum            
            var states = from Api.Models.Location.StateEnum e in Enum.GetValues(typeof(Api.Models.Location.StateEnum))
            select new
            {
                ID = (int)e,
                Name = UserInterface.Code.Enum.GetEnumDescription(e)
            };
            ViewBag.States = new SelectList(states, "ID", "Name");
            #endregion

            #region Generate risk home construction enum            
            var riskConstructions = from Api.Models.Home.RiskConstructionEnum e in Enum.GetValues(typeof(Api.Models.Home.RiskConstructionEnum))
            select new
            {
                ID = (int)e,
                Name = UserInterface.Code.Enum.GetEnumDescription(e)
            };
            ViewBag.RiskConstructions = new SelectList(riskConstructions, "ID", "Name");
            #endregion

            return View(new Api.Models.InsurancePolicy());
        }

        [HttpPost]
        public async Task<bool> Add(Api.Models.InsurancePolicy insurancePolicy)
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                var insurancePolicies = await api.Request<Api.Models.InsurancePolicy>(HttpMethod.Post, "InsurancePolicy", "", null, insurancePolicy);
                return true;
            }            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int insurancePolicyId)
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                var insurancePolicies = await api.Request<List<Api.Models.InsurancePolicy>>(HttpMethod.Get, "InsurancePolicy", $"insurancePolicyId={insurancePolicyId}", null, null);
                var insurancePolicy = insurancePolicies.Single();
                return View(insurancePolicy);
            }
        }

        [HttpPost]
        public async Task<bool> Delete(int insurancePolicyId)
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                bool response = await api.Request<bool>(HttpMethod.Delete, "InsurancePolicy", $"insurancePolicyId={insurancePolicyId}", null, null);
                return true;
            }
        }

        
    }
}
