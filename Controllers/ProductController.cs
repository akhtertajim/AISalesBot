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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _prod;
        ISpeechServices _spechServices;

        public ProductController(ILogger<ProductController> logger
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

        public IActionResult ProductDetails(string id)
        {
            var model=new ProductDetailsViewModel{
                Product=_prod.GetProduct(id)
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult ProductList(){
            var model=new ProductsViewModel{
                Products=_prod.GetProducts()
            };
              return PartialView("_Products",model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetSpeech(string id){
         return Json( _spechServices.GetProductSpeech(id));
        }
    }
}
