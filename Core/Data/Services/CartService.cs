using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using aisalesbot.Core.Data.IServices;
using Newtonsoft.Json;
using aisalesbot.Models;
using System.Data.Entity;

namespace aisalesbot.Core.Data.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddToCart(string userId, string prodId, int unit)
        {

            var cart = new UserCart
            {
                UserId = userId,
                ProductId = prodId,
                Unit = unit,
                IsCheckedOut = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _context.UserCart.Add(cart);
            _context.SaveChanges();
            //    var item=_context.UserCart.Where(a=>a.ProductId==prodId && a.UserId==userId && a.IsCheckedOut==false);
            //     if(item==null)
            //     {
            //         // _context.UserCart.Add(cart);
            //         // _context.SaveChanges();     
            //     }  
        }

        public IList<UserCart> GetUserCart(string userId)
        {
            return _context.UserCart.Where(a => a.UserId == userId && a.IsCheckedOut == false).ToList();
        }

        public void RemoveCartItem(int cartItemId)
        {
            UserCart cart = _context.UserCart.Where(a => a.Id == cartItemId).FirstOrDefault();
            _context.UserCart.Remove(cart);
            _context.SaveChanges();
        }

        public void OrderPlacement(PaymentDetails model, string userId)
        {

            var checkout = new CheckOut
            {
                CheckoutDate = DateTime.Now,
                PaymentMethod = "DebitCard",
                TotalAmount = model.CheckOutDetails.TotalAmount,
                TransactionNumber = DateTime.Now.ToString("ddmmyyhhmmss"),
                UserId = userId
            };
            SaveCheckOut(checkout, userId);
            var shipment = new ShipmentDetails
            {
                UserId = userId,
                CheckOutId = checkout.Id,

                DeliveryAddress = model.ShipmentDetails.DeliveryAddress,
                DeliveryEmail = model.ShipmentDetails.DeliveryEmail,
                DeliveryMobile = model.ShipmentDetails.DeliveryMobile
            };
            _context.ShipmentDetails.Add(shipment);
            _context.SaveChanges();
        }

        public void SaveCheckOut(CheckOut model, string userId)
        {
            _context.CheckOut.Add(model);
            _context.SaveChanges();

            var userCartItems = GetUserCart(userId);

            foreach (UserCart cart in userCartItems)
            {
                cart.IsCheckedOut = true;
                cart.CheckOutId = model.Id;
                cart.ExpectedDeliveryDate = DateTime.Now.AddDays(2);
                //  ShipmentWendor="aisalesbotshipment";
                // ExpectedDeliveryDate =DateTime.Now.AddDays(4);      
            }
            _context.SaveChanges();
        }

        public IList<CheckOut> GetCheckOutDetails(string userId)
        {

            return _context.CheckOut.Where(a => a.UserId == userId).ToList();
        }

        public int GetCartCount(string userId)
        {
            return _context.UserCart.Where(a => a.UserId == userId && a.IsCheckedOut == false).Count();
        }


        public void ApplyDiscount(decimal discount, string userId, string prodId)
        {
            var cart = _context.UserCart.Where(a => a.UserId == userId && a.ProductId == prodId && a.IsCheckedOut == false).FirstOrDefault();
            cart.Discount = discount;
            _context.SaveChanges();
        }
    }

}