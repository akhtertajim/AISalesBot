using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using aisalesbot.Core.Data.IServices;
using Newtonsoft.Json;

namespace aisalesbot.Core.Data.Services
{
    public class ProductServices:IProductServices{

        public IList<Product> GetProducts(){
            string filename="Core/Data/data-files/product.json";
            var res = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(filename));
            return res;
        }
        public Product GetProduct(string id){
            string filename="Core/Data/data-files/product.json";
            var res = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(filename));
            var prod =res.Where(prod=>prod.Id==id).FirstOrDefault();
            return prod;
        }

    }
}