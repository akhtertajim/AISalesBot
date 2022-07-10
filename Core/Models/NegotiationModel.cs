using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class NegotiationModel
{
    public string productId { get; set; }
    public string[] userQuries { get; set; }
    public string negotiationSlabsFirst { get; set; }
    public string negotiationSlabsSecond { get; set; }
    public string negotiationSlabsFinal { get; set; }
    public Product Product { get; set; }
    public bool allNegotiation { get; set; }
}

