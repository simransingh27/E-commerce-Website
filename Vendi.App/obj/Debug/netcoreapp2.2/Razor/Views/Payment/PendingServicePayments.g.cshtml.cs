#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90023fa38d584b0804f5bd235c6ee723dc6d00e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_PendingServicePayments), @"mvc.1.0.view", @"/Views/Payment/PendingServicePayments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payment/PendingServicePayments.cshtml", typeof(AspNetCore.Views_Payment_PendingServicePayments))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90023fa38d584b0804f5bd235c6ee723dc6d00e3", @"/Views/Payment/PendingServicePayments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_PendingServicePayments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vendi.App.Models.ServiceOrderModelView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ServiceMakePayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
  
    ViewData["Title"] = " My Pending Service Payments";


#line default
#line hidden
            BeginContext(128, 1136, true);
            WriteLiteral(@"

<style>
    .modal-backdrop {
        top: 2px;
        right: 5px;
        bottom: 1px;
        left: 1px;
        z-index: 1030;
        background-color: ghostwhite;
        position: unset;
    }
</style>



<div class=""cart-table-area section-padding-100"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-8 col-lg-12"">
                <div class=""cart-title mt-50"">
                    <h5>
                        <span class=""fa fa-credit-card"" style=""font-size:36px;color:#fbb710""></span>
                        My Pending Service Payments
                    </h5>
                </div>
                <div class=""cart-table clearfix"">
                    <table class=""table table-responsive"">
                        <thead>
                            <tr>
                                <th>Sevice Name</th>
                                 
                                <th>Total Amount</th>
                                <th>");
            WriteLiteral("Pay</th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
            EndContext();
#line 44 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(1353, 128, true);
            WriteLiteral("                                <tr>\r\n                                    <td >\r\n                                        <span> ");
            EndContext();
            BeginContext(1482, 16, false);
#line 48 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
                                          Write(item.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(1498, 182, true);
            WriteLiteral("</span>\r\n                                    </td>\r\n                                     \r\n                                    <td >\r\n                                        <span>£ ");
            EndContext();
            BeginContext(1681, 16, false);
#line 52 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
                                           Write(item.TotalAmount);

#line default
#line hidden
            EndContext();
            BeginContext(1697, 137, true);
            WriteLiteral("</span>\r\n                                    </td>\r\n                                    <td>   \r\n                                        ");
            EndContext();
            BeginContext(1834, 159, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90023fa38d584b0804f5bd235c6ee723dc6d00e37045", async() => {
                BeginContext(1931, 58, true);
                WriteLiteral("<i style=\"color:#fbb710\" class=\"fa fa-paypal fa-3x\">ay</i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
                                                                                                      WriteLiteral(item.ServiceOrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1993, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 58 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
                            }

#line default
#line hidden
            BeginContext(2108, 152, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2278, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 71 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Payment\PendingServicePayments.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(2348, 13, true);
                WriteLiteral("\r\n   \r\n\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vendi.App.Models.ServiceOrderModelView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
