#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfc4b8a739a10e51a911698b989e9f407973de32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Details_D1), @"mvc.1.0.view", @"/Views/Products/Details-D1.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Details-D1.cshtml", typeof(AspNetCore.Views_Products_Details_D1))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfc4b8a739a10e51a911698b989e9f407973de32", @"/Views/Products/Details-D1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Details_D1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Vendi.App.Models.ProductModelView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.3.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ProductDetails.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TagsCSS.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LoadProductImage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SubmitReview", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(87, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(89, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de326284", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(137, 157, true);
            WriteLiteral("\r\n<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js\"></script>\r\n\r\n<!------ Include the above in your HEAD tag ---------->\r\n\r\n \r\n");
            EndContext();
            BeginContext(294, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfc4b8a739a10e51a911698b989e9f407973de327630", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
            BeginContext(351, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(353, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfc4b8a739a10e51a911698b989e9f407973de328882", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(403, 72, true);
            WriteLiteral("\r\n\r\n\r\n<br>\r\n<div class=\"card border-0\">\r\n    <div class=\"row\">\r\n        ");
            EndContext();
            BeginContext(475, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfc4b8a739a10e51a911698b989e9f407973de3210219", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 20 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProductId);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
#line 20 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                          WriteLiteral(Model.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(548, 211, true);
            WriteLiteral("\r\n        <aside class=\"col-sm-4\">\r\n            <!------ Include the Imagess from db. ---------->\r\n\r\n            <article class=\"gallery-wrap\">\r\n                <div class=\"img-big-wrap\">\r\n\r\n                    ");
            EndContext();
            BeginContext(759, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfc4b8a739a10e51a911698b989e9f407973de3213153", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 27 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Images;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(816, 604, true);
            WriteLiteral(@"

                </div>

                <!--
                <div class=""img-small-wrap"">
                    <div class=""item-gallery""> <img src=""https://via.placeholder.com/100x100""> </div>
                    <div class=""item-gallery""> <img src=""https://via.placeholder.com/100x100""> </div>
                    <div class=""item-gallery""> <img src=""https://via.placeholder.com/100x100""> </div>
                    <div class=""item-gallery""> <img src=""https://via.placeholder.com/100x100""> </div>
                </div>
                    -->
            </article>

            Tags:
");
            EndContext();
#line 42 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
               string[] tages = Model.Tags.Split(',');
                if (tages != null)
                {

#line default
#line hidden
            BeginContext(1531, 39, true);
            WriteLiteral("                    <ul class=\"tags\">\r\n");
            EndContext();
#line 46 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                         foreach (var tag in tages)
                        {

#line default
#line hidden
            BeginContext(1650, 56, true);
            WriteLiteral("                            <li><a href=\"#\" class=\"tag\">");
            EndContext();
            BeginContext(1707, 3, false);
#line 48 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                                   Write(tag);

#line default
#line hidden
            EndContext();
            BeginContext(1710, 9, true);
            WriteLiteral("</a></li>");
            EndContext();
#line 48 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                                                     }

#line default
#line hidden
            BeginContext(1722, 27, true);
            WriteLiteral("                    </ul>\r\n");
            EndContext();
#line 50 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                }
            

#line default
#line hidden
            BeginContext(1783, 160, true);
            WriteLiteral("\r\n\r\n        </aside>\r\n        <aside class=\"col-sm-5\">\r\n            <article class=\"card-body m-0 pt-0 pl-5\">\r\n                <h3 class=\"title text-uppercase\">");
            EndContext();
            BeginContext(1944, 17, false);
#line 57 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                            Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1961, 791, true);
            WriteLiteral(@"</h3>

                <!------ Include the static rating from db. ---------->

                <div class=""rating"">
                    <div class=""stars"">
                        <span class=""fa fa-star checked""></span>
                        <span class=""fa fa-star checked""></span>
                        <span class=""fa fa-star checked""></span>
                        <span class=""fa fa-star""></span>
                        <span class=""fa fa-star""></span>
                        <span class=""review-no ml-2"">(41 reviews)</span>
                    </div>
                </div>
                <br />
                <!------ Optional. ---------->
                <dl class=""param param-feature"">
                    <dt>Condition</dt>
                    <dd>
");
            EndContext();
#line 76 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                          
                            var condition = Model.Condition;
                            if (condition == 1)
                            {

#line default
#line hidden
            BeginContext(2922, 48, true);
            WriteLiteral("                                <div>New</div>\r\n");
            EndContext();
#line 81 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(3066, 49, true);
            WriteLiteral("                                <div>Used</div>\r\n");
            EndContext();
#line 85 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(3173, 93, true);
            WriteLiteral("                    </dd>\r\n                </dl>\r\n\r\n                <div class=\"mb-3 mt-3\">\r\n");
            EndContext();
#line 91 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                      
                        var qty = Model.Quantity;
                        if (qty == 0)
                        {

#line default
#line hidden
            BeginContext(3407, 79, true);
            WriteLiteral("                            <span class=\"h7 text-danger\">Out of stock.</span>\r\n");
            EndContext();
#line 96 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(3570, 58, true);
            WriteLiteral("                            <span class=\"h7 text-success\">");
            EndContext();
            BeginContext(3629, 3, false);
#line 99 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                                     Write(qty);

#line default
#line hidden
            EndContext();
            BeginContext(3632, 19, true);
            WriteLiteral(" In stock.</span>\r\n");
            EndContext();
#line 100 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(3701, 189, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"mb-3 mt-3\">\r\n                    <span class=\"price-title\">Price :</span>\r\n                    <span class=\"price color-price-waanbii\">");
            EndContext();
            BeginContext(3891, 11, false);
#line 106 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                                                       Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(3902, 212, true);
            WriteLiteral("<sup>£</sup></span>\r\n                </div>\r\n                <dl class=\"item-property\">\r\n                    <dt>Description</dt>\r\n                    <dd>\r\n                         \r\n                            ");
            EndContext();
            BeginContext(4115, 17, false);
#line 112 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
                       Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(4132, 423, true);
            WriteLiteral(@"
                         
                    </dd>
                </dl>

            </article>
        </aside>
        <aside class=""col-sm-3"">
            <div class=""row"">
                <dl class=""param param-inline"">
                    <dt>Quantity: </dt>
                    <dd>
                        <select class=""form-control form-control-sm"" style=""width:70px;"">
                            ");
            EndContext();
            BeginContext(4555, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3222892", async() => {
                BeginContext(4563, 3, true);
                WriteLiteral(" 1 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4575, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4605, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3224094", async() => {
                BeginContext(4613, 3, true);
                WriteLiteral(" 2 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4625, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4655, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3225296", async() => {
                BeginContext(4663, 3, true);
                WriteLiteral(" 3 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4675, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4705, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3226498", async() => {
                BeginContext(4713, 3, true);
                WriteLiteral(" 4 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4725, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4755, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3227700", async() => {
                BeginContext(4763, 3, true);
                WriteLiteral(" 5 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4775, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4805, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3228902", async() => {
                BeginContext(4813, 3, true);
                WriteLiteral(" 6 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4825, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4855, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3230104", async() => {
                BeginContext(4863, 3, true);
                WriteLiteral(" 7 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4875, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4905, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3231306", async() => {
                BeginContext(4913, 3, true);
                WriteLiteral(" 8 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4925, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(4955, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3232508", async() => {
                BeginContext(4963, 3, true);
                WriteLiteral(" 9 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4975, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(5005, 21, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfc4b8a739a10e51a911698b989e9f407973de3233710", async() => {
                BeginContext(5013, 4, true);
                WriteLiteral(" 10 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5026, 541, true);
            WriteLiteral(@"
                        </select>
                    </dd>
                </dl>
            </div>
            <div class=""row "">
                <button class=""btn btn-lg color-box-waanbii"" type=""button""> <i class=""fa fa-shopping-cart""></i> Add to cart </button>
            </div>

            <div class=""row mb-4 mt-4"">
                <button class=""btn btn-lg btn-secondary"" id=""btnFav"" type=""button""><i class=""fa fa-heart fa-heart""></i></button>
            </div>



        </aside>
    </div>
</div>





");
            EndContext();
            BeginContext(5567, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfc4b8a739a10e51a911698b989e9f407973de3235442", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5599, 14, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5631, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 165 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Products\Details-D1.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(5701, 1853, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            iid = $('#ProductId').val();
            $.ajax({
                url: ""/Favorites/GetAPIFavoriteCheck/"" + iid,
                type: ""GET"",
                contentType: ""application/json;charset=utf-8"",
                dataType: ""json"",
                success: function (result) {
                    var flag1 = result.flag;
                    if (flag1) {
                        $('#btnFav').removeClass('btn btn-lg btn-secondary').addClass('btn btn-lg btn-danger');
                    } else {
                      
                        $('#btnFav').removeClass('btn btn-lg btn-danger').addClass('btn btn-lg btn-secondary');
                    }
                }
            });

            $('#btnFav').click(function () {
                    $.ajax({
                        url: ""/Favorites/GetAPIFavorite/"" + id,
                        type: ""GET"",
                        contentType: ""application/json;charset=ut");
                WriteLiteral(@"f-8"",
                        dataType: ""json"",
                        success: function (result) {
                            var flag = result.flag;
                            if (flag) {
                                $('#btnFav').removeClass('btn btn-lg btn-danger').addClass('btn btn-lg btn-secondary');
                            } else {
                               
                                $('#btnFav').removeClass('btn btn-lg btn-secondary').addClass('btn btn-lg btn-danger');
                            }
                            console.log(result);
                        },
                        error: function (errormessage) {
                            alert(errormessage);
                        }
                    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Vendi.App.Models.ProductModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
