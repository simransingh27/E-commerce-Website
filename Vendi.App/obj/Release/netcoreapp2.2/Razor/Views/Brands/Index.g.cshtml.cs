#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "375183f9e7369c87a0c79de570af815b07cd4bed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brands_Index), @"mvc.1.0.view", @"/Views/Brands/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Brands/Index.cshtml", typeof(AspNetCore.Views_Brands_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375183f9e7369c87a0c79de570af815b07cd4bed", @"/Views/Brands/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Brands_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vendi.Data.Brand>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("au-btn au-btn-icon au-btn--blue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("align", new global::Microsoft.AspNetCore.Html.HtmlString("Right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
  
    ViewData["Title"] = "Brands";
    Layout = "~/Views/Shared/_CPLayout.cshtml";

#line default
#line hidden
            BeginContext(131, 370, true);
            WriteLiteral(@"<div class=""main-content"">
    <div class=""section__content section__content--p30"">
        <div class=""container-fluid"">

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""overview-wrap"">
                        <h2 class=""title-1"">Brands</h2>
                        <!-- Satrtt -->
                        ");
            EndContext();
            BeginContext(501, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "375183f9e7369c87a0c79de570af815b07cd4bed5524", async() => {
                BeginContext(578, 43, true);
                WriteLiteral("  <i class=\"zmdi zmdi-plus\"></i>Add a Brand");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(625, 249, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n           <br/>\r\n            <table class=\"table table-hover \">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(875, 45, false);
#line 25 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.BrandName));

#line default
#line hidden
            EndContext();
            BeginContext(920, 93, true);
            WriteLiteral("\r\n                        </th>\r\n\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(1014, 46, false);
#line 29 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
            EndContext();
            BeginContext(1060, 148, true);
            WriteLiteral("\r\n                        </th>\r\n\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 36 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(1281, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1378, 44, false);
#line 40 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.BrandName));

#line default
#line hidden
            EndContext();
            BeginContext(1422, 105, true);
            WriteLiteral("\r\n                            </td>\r\n\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1528, 45, false);
#line 44 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CreateDate));

#line default
#line hidden
            EndContext();
            BeginContext(1573, 105, true);
            WriteLiteral("\r\n                            </td>\r\n\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1678, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "375183f9e7369c87a0c79de570af815b07cd4bed9765", async() => {
                BeginContext(1728, 55, true);
                WriteLiteral("<i style=\"color:#4272d7;\" class=\"fa fa-edit fa-2x\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                                                       WriteLiteral(item.BrandId);

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
            BeginContext(1787, 36, true);
            WriteLiteral(" |\r\n                                ");
            EndContext();
            BeginContext(1823, 119, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "375183f9e7369c87a0c79de570af815b07cd4bed12206", async() => {
                BeginContext(1876, 62, true);
                WriteLiteral("<i style=\"color:#4272d7;\" class=\"fa fa-info-circle fa-2x\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                                                          WriteLiteral(item.BrandId);

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
            BeginContext(1942, 38, true);
            WriteLiteral(" |\r\n                                <a");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1980, "\"", 2016, 3);
            WriteAttributeValue("", 1990, "DeleteBrand(", 1990, 12, true);
#line 50 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
WriteAttributeValue("", 2002, item.BrandId, 2002, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 2015, ")", 2015, 1, true);
            EndWriteAttribute();
            BeginContext(2017, 129, true);
            WriteLiteral("><i style=\"color:#4272d7;\" class=\"fa fa-trash fa-2x\"></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 53 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Brands\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2169, 750, true);
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>



<script>
    function DeleteBrand(id) {
        var r = confirm(""Are you sure to delete this Product."");
        if (r) {
            $.ajax({
                url: ""/DeleteBrand/"" + id,
                type: ""GET"",
                contentType: ""application/json;charset=utf-8"",
                dataType: ""json"",

                success: function (result) {

                    console.log(result);
                    location.reload();
                },
                error: function (errormessage) {
                    alert(errormessage);
                }
            });
        }
        location.reload();

    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vendi.Data.Brand>> Html { get; private set; }
    }
}
#pragma warning restore 1591