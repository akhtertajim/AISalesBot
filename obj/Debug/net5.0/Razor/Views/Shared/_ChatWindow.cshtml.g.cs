#pragma checksum "C:\Users\Tanveer\Desktop\project\aisalesbot\Views\Shared\_ChatWindow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd4a8400566e6f459a7629242c94f96b61838aba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ChatWindow), @"mvc.1.0.view", @"/Views/Shared/_ChatWindow.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd4a8400566e6f459a7629242c94f96b61838aba", @"/Views/Shared/_ChatWindow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18494138116cffd36132462976f9f7fcddaed582", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ChatWindow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""chatbox-holder"">
  <div class=""chatbox"">
    <div class=""chatbox-top"">
      <!-- <div class=""chatbox-avatar"">
        <a target=""_blank"" href=""https://www.facebook.com/mfreak""><img src=""https://gravatar.com/avatar/2449e413ade8b0c72d0a15d153febdeb?s=512&amp;d=https://codepen.io/assets/avatars/user-avatar-512x512-6e240cf350d2f1cc07c2bed234c3a3bb5f1b237023c204c782622e80d6b212ba.png""></a> 
      </div> -->
              <span class=""status online""></span>
              <div class=""chat-partner-name"">SALESBOT</div> 
      <!-- <div class=""chat-partner-name"">

         <a target=""_blank"" href=""https://www.facebook.com/mfreak"">Mamun Khandaker</a> 
      </div> -->
      <div class=""chatbox-icons"">
        <!-- <a href=""javascript:void(0);""><i class=""fa fa-minus""></i></a> -->
        <a href=""javascript:void(0);""><i class=""fa fa-close""></i></a>       
      </div>      
    </div>
    
    <div class=""chat-messages"" id=""chat-message-body"">
         <div class=""message-box-holder"">
   ");
            WriteLiteral("   <div class=\"message-box\">\r\n        Hello\r\n      </div>\r\n    </div>\r\n\r\n    \r\n\r\n    </div>\r\n    \r\n    <div class=\"chat-input-holder\">\r\n      <textarea class=\"chat-input\" id=\"chatinput\" placeholder=\"Type Here..\"></textarea>\r\n      <button type=\"button\"");
            BeginWriteAttribute("value", " value=\"", 1276, "\"", 1284, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""message-send"" placeholder=""type here.."" id=""btn-postusermsg""><i class=""fa fa-paper-plane"" aria-hidden=""true""></i></button>
      <!-- <input type=""submit"" value=""Send"" class=""message-send""> -->
    </div>
    <div class=""attachment-panel"">
      <a href=""#"" class=""fa fa-thumbs-up""></a>
      <a href=""#"" class=""fa fa-camera""></a>
      <a href=""#"" class=""fa fa-video-camera""></a>
      <a href=""#"" class=""fa fa-image""></a>
      <a href=""#"" class=""fa fa-paperclip""></a>
      <a href=""#"" class=""fa fa-link""></a>
      <a href=""#"" class=""fa fa-trash-o""></a>
      <a href=""#"" class=""fa fa-search""></a>
    </div>
  </div>
  
  
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
