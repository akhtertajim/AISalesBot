using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

namespace aisalesbot.Models
{
    public class DeleiveryOptionsViewModel{
        public decimal TotalAmmount{get;set;}
        public int TotalItems{get;set;}
        public string Address1{get;set;}
        public string Address2{get;set;}
        public string PinCode{get;set;}
        
        public string DeliveryAddress{
            get{
                return Address1+Address2+PinCode;
            }
        }
        
        public string Email {get;set;}
        public string Mobile {get;set;}
    }
}