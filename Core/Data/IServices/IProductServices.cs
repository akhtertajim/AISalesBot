using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

namespace aisalesbot.Core.Data.IServices
{
    public interface IProductServices{
        IList<Product> GetProducts(); 
        Product GetProduct(string id);
    }
}