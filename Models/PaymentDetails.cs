using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

namespace aisalesbot.Models
{
    public class PaymentDetails{
        public CheckOut CheckOutDetails{get;set;}  
        public ShipmentDetails ShipmentDetails{get;set;}
    }
}
