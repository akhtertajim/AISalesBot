using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections;

namespace aisalesbot.Core.Data.IServices
{
    public interface ISpeechServices{
        ProductSpeech GetProductSpeech(string prodId);
        NegotiationModel GetPricingTemplate(string prodId);
    }
}


