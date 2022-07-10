using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

public class ShipmentDetails{ 
    public virtual int Id {get;set;}
	public virtual string UserId {get;set;}
 	public virtual int CheckOutId {get;set;}
	public virtual string DeliveryAddress {get;set;}
	public virtual string DeliveryEmail {get;set;}
	public virtual string DeliveryMobile {get;set;}
	public virtual CheckOut CheckOut{get;set;}
}