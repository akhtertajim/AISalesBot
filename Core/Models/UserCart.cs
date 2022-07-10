using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

public class UserCart {
    public int Id {get;set;}
    public string UserId {get;set;}
	public string ProductId {get;set;}
	public int Unit {get;set;}
	public DateTime CreatedDate {get;set;}
	public DateTime ModifiedDate {get;set;}
	public bool IsCheckedOut{get;set;}
    public virtual int? CheckOutId{get;set;}
	public DateTime? ExpectedDeliveryDate {get;set;}
	public DateTime? ReceivedByUserDate {get;set;}
	public string ShipmentWendor {get;set;}
	public decimal Discount { get; set; }
	public virtual CheckOut CheckOut{get;set;}

	[NotMapped] 
	public Product Product{get;set;}
}