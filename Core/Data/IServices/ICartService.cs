using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using aisalesbot.Models;

namespace aisalesbot.Core.Data.IServices
{
    public interface ICartService{
        void AddToCart(string userId,string prodId, int unit);
        IList<UserCart> GetUserCart(string userId);
        void RemoveCartItem(int cartItemId);
        void OrderPlacement(PaymentDetails model,string userId);
        IList<CheckOut> GetCheckOutDetails(string userId);
        int GetCartCount(string userId);
        void ApplyDiscount(decimal discount, string userId, string prodId);
    }
}


