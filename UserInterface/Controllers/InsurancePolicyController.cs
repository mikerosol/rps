using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Add()
        {
            #region ENUM            
            var enumData = from Api.Models.Location.StateEnum e in Enum.GetValues(typeof(Api.Models.Location.StateEnum))
            select new
            {
                ID = (int)e,
                Name = e.ToString()
            };
            ViewBag.States = new SelectList(enumData, "ID", "Name");
            //ViewBag.States.Add(new SelectListItem("Please Select..., """));
            #endregion

            return View(new Api.Models.InsurancePolicy());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Api.Models.InsurancePolicy insurancePolicy)
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                var insurancePolicies = await api.Request<Api.Models.InsurancePolicy>(HttpMethod.Post, "InsurancePolicy", "", null, insurancePolicy);
                return RedirectToAction("Index");
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
        public async Task<IActionResult> Delete(int insurancePolicyId)
        {
            using (var api = await Task.Run(() => new UserInterface.Service.Api()))
            {
                bool response = await api.Request<bool>(HttpMethod.Delete, "InsurancePolicy", $"insurancePolicyId={insurancePolicyId}", null, null);
                return RedirectToAction("Index");
            }
        }
    }
}
