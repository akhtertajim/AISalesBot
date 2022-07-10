using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

public class Product {
    public ProductCategory ProductCategory { get; set; } 
    public string Id { get; set; } 
    public string DisplayShortText { get; set; } 
    public string DisplayFullText { get; set; } 
    public int UserRating { get; set; } 
    public decimal UnitPrice{get;set;}
    public string Price { get{return "₹ " +Convert.ToString(UnitPrice);} } 
    public int Discount { get; set; } 
    public string Description { get; set; } 
    public IList<string> Heighlights { get; set; } 
    public IList<string> Colors { get; set; } 
    public IList<string> ImgSmall { get; set; } 
    public IList<object> ImgLarge { get; set; } 

}