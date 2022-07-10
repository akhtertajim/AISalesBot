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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using aisalesbot.Models;

namespace aisalesbot.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductServices _prod;
        ISpeechServices _spechServices;
        ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ILogger<CartController> logger
        ,IProductServices prod, ISpeechServices speechSrvice,
         ICartService cartService,
          UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _prod=prod;
            _spechServices=speechSrvice;
            _cartService=cartService;
            _userManager=userManager;
        }

        public IActionResult Index()
        {
         var user=GetCurrentUserAsync().Result;
         var cartItems=_cartService.GetUserCart(_userManager.GetUserId(User));

         var prods=(from p in  _prod.GetProducts()
                    join c in cartItems on p.Id equals c.ProductId
                    select p).ToList();

           foreach(var cart in cartItems){
               cart.Product=prods.Where(a=>a.Id==cart.ProductId).FirstOrDefault();
           }

            var model=new CartViewModel{
                CartItems=cartItems,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult GetSpeech(string id){
         return Json( _spechServices.GetProductSpeech(id));
        }

        [HttpPost]
        public IActionResult AddToCart(string prodId){
            if (string.IsNullOrWhiteSpace(prodId))
            {
                return Json(new {
                    IsSuccss = false
                });
            }
            string userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, prodId,1);
            
            var model=new {
                 IsSuccss=true,
                 CartCount=_cartService.GetCartCount(userId)
             };
             return Json(model);
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            string userId = _userManager.GetUserId(User);
            return Content( _cartService.GetCartCount(userId).ToString());
        }
        
        [HttpGet,HttpPost]
        public IActionResult BuyNow(string prodId){
         var user=GetCurrentUserAsync().Result;
         _cartService.AddToCart(_userManager.GetUserId(User), prodId,1);
         return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveCartItem(int cartItemId){
            _cartService.RemoveCartItem(cartItemId);
            return Json(new{
                IsSuccss=true
            });
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet]
        public ActionResult DeleiveryOptions()
        {
            var user = GetCurrentUserAsync().Result;
            var cartItems =_cartService.GetUserCart(_userManager.GetUserId(User));

            var prods=(from p in  _prod.GetProducts()
                    join c in cartItems on p.Id equals c.ProductId
                    select p).ToList();
            decimal totlAmount=0;
            int totlItems=0;
            decimal disc = 0;
            foreach (var cart in cartItems){
               var prd=prods.Where(a=>a.Id==cart.ProductId).FirstOrDefault();
                totlAmount+=(prd.UnitPrice*cart.Unit);
                totlItems+=cart.Unit;
                disc += cart.Discount;
           }

            var model=new DeleiveryOptionsViewModel
            {
                TotalAmmount=totlAmount- disc,
                TotalItems=totlItems,
                Email=user.Email,
                Mobile=user.PhoneNumber                
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult DeleiveryOptions(DeleiveryOptionsViewModel model)
        {
            TempData["DeleiveryOptionsViewModel"]= Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return RedirectToAction("Payment");
        }

        [HttpGet]
        public ActionResult Payment(){
            DeleiveryOptionsViewModel del=  Newtonsoft.Json.JsonConvert.DeserializeObject<DeleiveryOptionsViewModel>((string)TempData["DeleiveryOptionsViewModel"]);
            
          var cartItems=_cartService.GetUserCart(_userManager.GetUserId(User));

            var prods=(from p in  _prod.GetProducts()
                    join c in cartItems on p.Id equals c.ProductId
                    select p).ToList();
            decimal totlAmount=0;
            int totlItems=0;
            decimal disc = 0;
            foreach (var cart in cartItems){
               var prd=prods.Where(a=>a.Id==cart.ProductId).FirstOrDefault();
                totlAmount+=(prd.UnitPrice*cart.Unit);
                disc += cart.Discount;
           }

            var model=new PaymentDetails{
                ShipmentDetails=new ShipmentDetails{
                    DeliveryAddress=del?.DeliveryAddress,    
                    DeliveryEmail=del?.Email,  
                    DeliveryMobile=del?.Mobile               
                },
                CheckOutDetails=new CheckOut{
                    TotalAmount=totlAmount- disc,
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult PaymentSubmition(PaymentDetails model){
            _cartService.OrderPlacement(model,_userManager.GetUserId(User));
            return RedirectToAction("MyOrders");
        }

        [HttpGet]
        public ActionResult MyOrders()        
        {
          var checkoutlist=  _cartService.GetCheckOutDetails(_userManager.GetUserId(User));
          var model=new MyOrdersViewModel{
              OrderList=checkoutlist,
              Products = _prod.GetProducts()
          };
          return View(model);
        }

        [HttpPost]
        public ActionResult ApplyDiscount(decimal disc,string prodId)
        {
            _cartService.ApplyDiscount(disc, _userManager.GetUserId(User), prodId);
            return Json(new { success = true });
        }
    }
}
