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
    public class SpeechServices:ISpeechServices{

        private IProductServices _prod;
        public SpeechServices(IProductServices prod)
        {
            _prod = prod;
        }

        public ProductSpeech GetProductSpeech(string prodId){
            string filename="Core/Data/data-files/speach-products.json";
            var res = JsonConvert.DeserializeObject<List<ProductSpeech>>(File.ReadAllText(filename));
            var speechData =res.Where(speech=>speech.productId==prodId).FirstOrDefault();
            var prod = _prod.GetProduct(prodId);
            string text = speechData.speechText
                .Replace("#$ProductName$#", prod.DisplayShortText)
                .Replace("#$Price$#",prod.Price)
                .Replace("#$UserRatings$#", prod.UserRating.ToString());

            speechData.speechText = text;
            return speechData;
        } 
        
        public NegotiationModel GetPricingTemplate(string prodId)
        {
            string filename = "Core/Data/data-files/price-negotiation-template.json";
            var res = JsonConvert.DeserializeObject<List<NegotiationModel>>(File.ReadAllText(filename));
            var temp= res.Where(speech => speech.productId == prodId).FirstOrDefault();
            temp.Product = _prod.GetProduct(prodId);
            return temp;
        }
    }
}