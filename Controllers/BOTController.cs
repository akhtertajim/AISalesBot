using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aisalesbot.Models;
using aisalesbot.Core.Data.IServices;

namespace aisalesbot.Controllers
{
    public class BOTController : Controller
    {
        private readonly ILogger<BOTController> _logger;
        private readonly IProductServices _prod;
        ISpeechServices _spechServices;

        public BOTController(ILogger<BOTController> logger
        ,IProductServices prod, ISpeechServices speechSrvice)
        {
            _logger = logger;
            _prod=prod;
            _spechServices=speechSrvice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetSpeech(string id){
            var speech = _spechServices.GetProductSpeech(id);
             return Json(speech);
        }

        [HttpGet]
        public IActionResult GetNegotiationTemplate(string prodId)
        {
            var data = _spechServices.GetPricingTemplate(prodId);
            return Json(data);
        }
    }
}
