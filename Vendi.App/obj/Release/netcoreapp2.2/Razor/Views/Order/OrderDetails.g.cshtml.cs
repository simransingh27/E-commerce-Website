#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90ddd6bcfe9713755e87ce4227e30072fe0acf36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderDetails), @"mvc.1.0.view", @"/Views/Order/OrderDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/OrderDetails.cshtml", typeof(AspNetCore.Views_Order_OrderDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ddd6bcfe9713755e87ce4227e30072fe0acf36", @"/Views/Order/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vendi.App.Models.OrderModelView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Image/Vendi/Logo_Vendi.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
  
    ViewData["Title"] = "OrderDetails";


#line default
#line hidden
            BeginContext(103, 764, true);
            WriteLiteral(@"
<div class=""cart-table-area section-padding-100"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12 col-lg-8"">
                <div class=""cart-title mt-50"">
                    <h2> My Order Details</h2>
                </div>
                <div class=""cart-table clearfix"">
                    <table class=""table table-responsive table-hover"">
                        <thead>
                            <tr>
                                <th>Image</th>
                                <th>Name</th>
                                <th>Price</th>
                                <th>Quantity</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 25 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(956, 157, true);
            WriteLiteral("                                <tr>\r\n                                    <td class=\"cart_product_img\">\r\n                                        <a href=\"#\">");
            EndContext();
            BeginContext(1113, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "90ddd6bcfe9713755e87ce4227e30072fe0acf365443", async() => {
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
            BeginContext(1167, 164, true);
            WriteLiteral("</a>\r\n                                    </td>\r\n                                    <td class=\"cart_product_desc\">\r\n                                        <span> ");
            EndContext();
            BeginContext(1332, 16, false);
#line 32 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
                                          Write(item.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1348, 158, true);
            WriteLiteral("</span>\r\n                                    </td>\r\n\r\n                                    <td class=\"price\">\r\n                                        <span>£ ");
            EndContext();
            BeginContext(1507, 10, false);
#line 36 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
                                           Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1517, 295, true);
            WriteLiteral(@"</span>
                                    </td>
                                    <td class=""qty"">
                                        <div class=""qty-btn d-flex"">
                                            <div class=""quantity"">
                                                <p>");
            EndContext();
            BeginContext(1813, 13, false);
#line 41 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
                                              Write(item.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1826, 188, true);
            WriteLiteral("</p>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 46 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
                            }

#line default
#line hidden
            BeginContext(2045, 645, true);
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>

            <div class=""col-12 col-lg-4"">
                <div class=""cart-summary"">
                    <h5>Cart Total</h5>
                    <ul class=""summary-table"">
                        <li><span>Subtotal:</span> <span class=""spantotal""></span></li>
                        <li><span>Delivery:</span> <span>Free</span></li>
                        <li><span>total:</span> <span class=""spantotal""></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2708, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 67 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Order\OrderDetails.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(2778, 454, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

            $.ajax({
                url: ""/GetCartTotal"",
                type: ""GET"",
                contentType: ""application/json;charset=utf-8"",
                dataType: ""json"",
                success: function (result) {
                    console.log(result);
                    $("".spantotal"").html(result);
                }
            });
        });

    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vendi.App.Models.OrderModelView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
