#pragma checksum "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e13bb5971cf7a0fc0379624f3fc406405f51be8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Payment), @"mvc.1.0.view", @"/Views/Cart/Payment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\_ViewImports.cshtml"
using aisalesbot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\_ViewImports.cshtml"
using aisalesbot.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e13bb5971cf7a0fc0379624f3fc406405f51be8", @"/Views/Cart/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18494138116cffd36132462976f9f7fcddaed582", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<aisalesbot.Models.PaymentDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Cart/PaymentSubmition"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml"
  
     ViewData["Title"] = "Payment Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\" >\r\n <div class=\"card-header\">\r\n    Complete Payment Details\r\n  </div>\r\n    <div class=\"card-body\">\r\n      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e13bb5971cf7a0fc0379624f3fc406405f51be84217", async() => {
                WriteLiteral("\r\n       <input type=\"hidden\" name=\"ShipmentDetails.DeliveryAddress\"");
                BeginWriteAttribute("value", " value=\"", 341, "\"", 387, 1);
#nullable restore
#line 13 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml"
WriteAttributeValue("", 349, Model.ShipmentDetails.DeliveryAddress, 349, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n       <input type=\"hidden\" name=\"ShipmentDetails.DeliveryEmail\"");
                BeginWriteAttribute("value", " value=\"", 455, "\"", 499, 1);
#nullable restore
#line 14 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml"
WriteAttributeValue("", 463, Model.ShipmentDetails.DeliveryEmail, 463, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n       <input type=\"hidden\" name=\"ShipmentDetails.DeliveryMobile\"");
                BeginWriteAttribute("value", " value=\"", 568, "\"", 613, 1);
#nullable restore
#line 15 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml"
WriteAttributeValue("", 576, Model.ShipmentDetails.DeliveryMobile, 576, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
        <div class=""form-group row"">
            <label for=""totalAmount"" class=""col-sm-2 col-form-label"">Total Amount</label>
            <div class=""col-sm-6"">
            <input type=""text"" name=""CheckOutDetails.TotalAmount"" readonly class=""form-control-plaintext"" id=""TotalAmount""");
                BeginWriteAttribute("value", " value=\"", 904, "\"", 946, 1);
#nullable restore
#line 19 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Payment.cshtml"
WriteAttributeValue("", 912, Model.CheckOutDetails.TotalAmount, 912, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
            </div>
        </div>
        <div class=""form-group row"">
            <label for=""CardNumber"" class=""col-sm-2 col-form-label"">Card Number</label>
            <div class=""col-sm-6"">
            <input type=""text"" class=""form-control"" id=""CardNumber"" placeholder=""Card Number"">
            </div>
        </div>
        <div class=""form-group row"">
            <label for=""CVV"" class=""col-sm-2 col-form-label"">CVV</label>
            <div class=""col-sm-2"">
            <input type=""text"" class=""form-control"" id=""CVV"" placeholder=""CVV"">
            </div>
        </div>

        <button type=""submit"" class=""btn btn-primary"">Pay</button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<aisalesbot.Models.PaymentDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
