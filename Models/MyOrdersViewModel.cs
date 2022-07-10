using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aisalesbot.Models{

    public class MyOrdersViewModel{
        public IList<CheckOut> OrderList{get;set;}
        public IList<Product> Products{get;set;}
    }
}