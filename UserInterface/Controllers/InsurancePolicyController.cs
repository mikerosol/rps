using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;
using System.Net.Http;

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

        //[HttpGet]
        //public async Task<ActionResult> Details(int? quoteId = null)
        //{
        //    using (var api = Global.Api)
        //    {
        //        var quote = new Objects.InsurancePolicy();

        //        //NEW QUOTE
        //        if (quoteId == null)
        //        {
        //            //quote = await api.Request<Objects.Quote>(HttpMethod.Post, "Quote", "", null, quote);
        //            var quotes = new List<Objects.InsurancePolicy>();
        //        }
        //        //EXISITNG QUOTE
        //        else
        //        {
        //            //var quotes = await api.Request<List<Objects.Quote>>(HttpMethod.Get, "Quote", $"quoteId={quoteId}", null, null);
        //            var quotes = new List<Objects.InsurancePolicy>();
        //            quote = quotes.Single();
        //        }
        //        return View(quote);
        //    }
        //}

        //[HttpPost]
        //public async Task<bool> Delete(int quoteId)
        //{
        //    using (var api = Global.Api)
        //    {
        //        //await api.Request<Objects.Quote>(HttpMethod.Delete, "Quote", $"quoteId={quoteId}", null, null);
        //        return true;
        //    }
        //}
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
