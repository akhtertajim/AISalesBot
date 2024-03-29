#pragma checksum "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4ff0eccf3d73338ab6442425969b882c8aed3c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4ff0eccf3d73338ab6442425969b882c8aed3c2", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18494138116cffd36132462976f9f7fcddaed582", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<aisalesbot.Models.CartViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Cart/DeleiveryOptions"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Cart";
    decimal totalAmout=0;
    decimal discount = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d4ff0eccf3d73338ab6442425969b882c8aed3c23807", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
 if(Model==null || Model.CartItems.Count<1)
{

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"card product-details\">\r\n  <div class=\"row g-0\">\r\n     <div class=\"col-md-6\">\r\n        <div class=\"card-body\">\r\n          Cart Is Empty\r\n        </div>\r\n     </div>\r\n  </div>\r\n</div>\r\n");
#nullable restore
#line 20 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
}
else
{
    foreach(var cart in Model.CartItems)
    {
        totalAmout+=cart.Product?.UnitPrice??0;
        discount = cart.Discount;

#line default
#line hidden
#nullable disable
                WriteLiteral("    <div class=\"card product-details\" data-cart-itemid=\"");
#nullable restore
#line 27 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
                                                   Write(cart.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">\r\n    <div class=\"row g-0\">\r\n       <div class=\"col-md-2\">\r\n        <img class=\"card-img-top\"");
                BeginWriteAttribute("src", " src=\"", 724, "\"", 755, 1);
#nullable restore
#line 30 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
WriteAttributeValue("", 730, cart.Product.ImgSmall[0], 730, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"Card image cap\">\r\n     </div>\r\n         <div class=\"col-md-4\">\r\n             <div class=\"card-body\">\r\n                  <h5 class=\"card-title\">");
#nullable restore
#line 34 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
                                    Write(cart.Product.DisplayShortText);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h5>
                   <button class=""btn btn-primary btn-sm btn-remove-cart"" type=""button"" ><i class=""fa fa-shopping-cart mr-1""></i>Remove From Cart</button>
             </div>
         </div>
         <div class=""col-md-3"">
            <div class=""card-body"">
          <button class=""btn btn-success  btn-sm"" style=""margin-top: -3px;""> <i class=""fa fa-plus""></i></button>
             <input type=""number""  style=""width: 51px;display:initial;"" class=""form-control form-control-sm""");
                BeginWriteAttribute("value", " value=\"", 1428, "\"", 1446, 1);
#nullable restore
#line 41 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1436, cart.Unit, 1436, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" width=""60px"" >
          <button class=""btn btn-success  btn-sm"" style=""margin-top: -3px;""> <i class=""fa fa-minus""></i></button>
         </div>
           </div>
           <div class=""col-md-3"">
              <div class=""card-body"">
              <p class=""card-text text-right""><strong>");
#nullable restore
#line 47 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
                                                  Write(cart.Product.UnitPrice- cart.Discount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong> </p>\r\n              </div>\r\n           </div>\r\n    </div>\r\n  </div>\r\n");
#nullable restore
#line 52 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"

  }

 


#line default
#line hidden
#nullable disable
                WriteLiteral("  <button class=\"btn btn-primary\">Checkout ₹  ");
#nullable restore
#line 57 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
                                          Write(totalAmout-discount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n");
#nullable restore
#line 58 "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Cart\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
  $("".btn-remove-cart"").on(""click"",function(){
    var itemid=$(this).closest("".product-details"").data(""cart-itemid"");
    var data={
      cartItemId:itemid
    };
  
    $.post(""/Cart/RemoveCartItem"",data)
    .done(function(resp){
      window.location.reload();
    })
    .fail(function(xhr,error,err){
      alert(""An error occured"");
      console.log(xhr);
    });
  });
</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<aisalesbot.Models.CartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
