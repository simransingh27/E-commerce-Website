#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_LoadProductImage - D1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4761949b8f072152efb82d451056bd0d1b0a0d7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoadProductImage___D1), @"mvc.1.0.view", @"/Views/Shared/_LoadProductImage - D1.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_LoadProductImage - D1.cshtml", typeof(AspNetCore.Views_Shared__LoadProductImage___D1))]
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
#line 1 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\_ViewImports.cshtml"
using Vendi.App;

#line default
#line hidden
#line 2 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\_ViewImports.cshtml"
using Vendi.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4761949b8f072152efb82d451056bd0d1b0a0d7e", @"/Views/Shared/_LoadProductImage - D1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoadProductImage___D1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vendi.Data.ProductImage>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ProductImageGallary/albery.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ProductImageGallary/albery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 101, true);
            WriteLiteral("<link href=\"https://www.jqueryscript.net/css/jquerysctipttop.css\" rel=\"stylesheet\" type=\"text/css\">\r\n");
            EndContext();
            BeginContext(146, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4761949b8f072152efb82d451056bd0d1b0a0d7e4561", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(215, 92, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n    <div class=\"albery-container\">\r\n\r\n        <div class=\"albery-wrapper\">\r\n\r\n");
            EndContext();
#line 14 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_LoadProductImage - D1.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(364, 101, true);
            WriteLiteral("                <div class=\"albery-item\" style=\"width:450px;height:450px;\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 465, "\"", 486, 1);
#line 17 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_LoadProductImage - D1.cshtml"
WriteAttributeValue("", 471, item.ImagePath, 471, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 487, "\"", 508, 1);
#line 17 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_LoadProductImage - D1.cshtml"
WriteAttributeValue("", 493, item.ProductId, 493, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(509, 27, true);
            WriteLiteral(">\r\n                </div>\r\n");
            EndContext();
#line 19 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_LoadProductImage - D1.cshtml"
            }

#line default
#line hidden
            BeginContext(551, 258, true);
            WriteLiteral(@"


        </div>

        <div class=""move-right"">
            <a href=""#"" id=""rightArrow""></a>
        </div>
        <div class=""move-left"">
            <a href=""#"" id=""leftArrow""></a>
        </div>

    </div>
    
  
 







 
");
            EndContext();
            BeginContext(809, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4761949b8f072152efb82d451056bd0d1b0a0d7e7615", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(867, 114, true);
            WriteLiteral("\r\n<script>\r\n    $(\".albery-container\").albery({\r\n        speed: 500,\r\n        imgWidth: 600,\r\n    });\r\n</script>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vendi.Data.ProductImage>> Html { get; private set; }
    }
}
#pragma warning restore 1591
