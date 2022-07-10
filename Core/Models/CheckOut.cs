using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

public class CheckOut{
	private readonly ILazyLoader _lazyLoader;

    public CheckOut()
    {

    }
	public CheckOut(ILazyLoader lazyLoader)
	{
		_lazyLoader = lazyLoader;
	}
	public int Id {get;set;}
	public string UserId{get;set;}
	public DateTime CheckoutDate {get;set;}
	public string PaymentMethod {get;set;}
	public decimal TotalAmount {get;set;}
	public string TransactionNumber {get;set;}
	private ShipmentDetails _shipmentDetails;
	public virtual ShipmentDetails ShipmentDetails{
		get => _lazyLoader.Load(this, ref _shipmentDetails);
		set => _shipmentDetails = value;
	}
	public virtual ICollection<UserCart> UserCarts{get;set;}

	private int? pendingDeliveryCount = null;

	[NotMapped]
	public bool AllItemsDelivered { get
        {
			return (pendingDeliveryCount <= 0);
        } }

	[NotMapped]
	public string DeliveryStatus
    {
        get
        {
            if (pendingDeliveryCount ==null)
            {
				pendingDeliveryCount = this.UserCarts.Where(a => a.ExpectedDeliveryDate > DateTime.Now).Count();
			}

            if (pendingDeliveryCount > 0)
            {
				return $"{pendingDeliveryCount}/{this.UserCarts.Count()} items to be delivered yet";
            }
			return $"Delivered all {this.UserCarts.Count()} items";
		}
    }
}