#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcb5f54b100dbc085b33011fe84beab9e183a845"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CP_Index), @"mvc.1.0.view", @"/Views/CP/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CP/Index.cshtml", typeof(AspNetCore.Views_CP_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcb5f54b100dbc085b33011fe84beab9e183a845", @"/Views/CP/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_CP_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Vendi.App.Models.CPModelView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_CPLayout.cshtml";

#line default
#line hidden
            BeginContext(127, 914, true);
            WriteLiteral(@"

<div class=""main-content"">
    <div class=""section__content section__content--p30"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""overview-wrap"">
                        <h2 class=""title-1"">overview</h2>

                    </div>
                </div>
            </div>
            <div class=""row m-t-25"">
                <div class=""col-sm-6 col-lg-3"">
                    <div class=""overview-item overview-item--c1"">
                        <div class=""overview__inner"">
                            <div class=""overview-box clearfix"">
                                <div class=""icon"">
                                    <i class=""zmdi zmdi-account-o""></i>
                                </div>
                                <div class=""text"">
                                    <h2>");
            EndContext();
            BeginContext(1042, 19, false);
#line 28 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                   Write(Model.NumberOfUsers);

#line default
#line hidden
            EndContext();
            BeginContext(1061, 885, true);
            WriteLiteral(@"</h2>
                                    <span>members</span>
                                </div>
                            </div>
                            <div class=""overview-chart"">
                                <canvas id=""widgetChart1""></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6 col-lg-3"">
                    <div class=""overview-item overview-item--c2"">
                        <div class=""overview__inner"">
                            <div class=""overview-box clearfix"">
                                <div class=""icon"">
                                    <i class=""zmdi zmdi-shopping-cart""></i>
                                </div>
                                <div class=""text"">
                                    <h2>");
            EndContext();
            BeginContext(1947, 22, false);
#line 46 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                   Write(Model.NumberOfProducts);

#line default
#line hidden
            EndContext();
            BeginContext(1969, 886, true);
            WriteLiteral(@"</h2>
                                    <span>Products</span>
                                </div>
                            </div>
                            <div class=""overview-chart"">
                                <canvas id=""widgetChart2""></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6 col-lg-3"">
                    <div class=""overview-item overview-item--c3"">
                        <div class=""overview__inner"">
                            <div class=""overview-box clearfix"">
                                <div class=""icon"">
                                    <i class=""zmdi zmdi-calendar-note""></i>
                                </div>
                                <div class=""text"">
                                    <h2>");
            EndContext();
            BeginContext(2856, 22, false);
#line 64 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                   Write(Model.NumberOfServices);

#line default
#line hidden
            EndContext();
            BeginContext(2878, 885, true);
            WriteLiteral(@"</h2>
                                    <span>Services</span>
                                </div>
                            </div>
                            <div class=""overview-chart"">
                                <canvas id=""widgetChart3""></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6 col-lg-3"">
                    <div class=""overview-item overview-item--c4"">
                        <div class=""overview__inner"">
                            <div class=""overview-box clearfix"">
                                <div class=""icon"">
                                    <i class=""zmdi zmdi-puzzle-piece""></i>
                                </div>
                                <div class=""text"">
                                    <h2>");
            EndContext();
            BeginContext(3764, 20, false);
#line 82 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                   Write(Model.NumberOfOrders);

#line default
#line hidden
            EndContext();
            BeginContext(3784, 1191, true);
            WriteLiteral(@"</h2>
                                    <span>Orders</span>
                                </div>
                            </div>
                            <div class=""overview-chart"">
                                <canvas id=""widgetChart4""></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-lg-9"">
                    <h2 class=""title-1 m-b-25"">Last 10 Orders</h2>
                    <div class=""table-responsive table--no-card m-b-40"">
                        <table class=""table table-borderless table-striped table-earning"">
                            <thead>
                                <tr>
                                    <th>date</th>
                                    <th>order ID</th>                                    
                                    
                                   
                  ");
            WriteLiteral("                  <th class=\"text-right\">total</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 109 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                 foreach (var item in Model.Last10Orders)
                                {

#line default
#line hidden
            BeginContext(5085, 88, true);
            WriteLiteral("                                    <tr>\r\n                                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5173, "\"", 5213, 2);
            WriteAttributeValue("", 5180, "/Order/OrderDetails/", 5180, 20, true);
#line 112 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
WriteAttributeValue("", 5200, item.OrderId, 5200, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5214, 25, true);
            WriteLiteral(" style=\"color:#808080;\"> ");
            EndContext();
            BeginContext(5240, 14, false);
#line 112 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                                                                                           Write(item.OrderDate);

#line default
#line hidden
            EndContext();
            BeginContext(5254, 59, true);
            WriteLiteral(" </a></td>\r\n                                        <td> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5313, "\"", 5353, 2);
            WriteAttributeValue("", 5320, "/Order/OrderDetails/", 5320, 20, true);
#line 113 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
WriteAttributeValue("", 5340, item.OrderId, 5340, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5354, 25, true);
            WriteLiteral(" style=\"color:#808080;\"> ");
            EndContext();
            BeginContext(5380, 12, false);
#line 113 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                                                                                            Write(item.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(5392, 117, true);
            WriteLiteral(" </a> </td>                                       \r\n                                        <td class=\"text-right\">£ ");
            EndContext();
            BeginContext(5510, 10, false);
#line 114 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                                            Write(item.Total);

#line default
#line hidden
            EndContext();
            BeginContext(5520, 134, true);
            WriteLiteral("</td>\r\n                                        \r\n                                        \r\n                                    </tr>\r\n");
            EndContext();
#line 118 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(5689, 555, true);
            WriteLiteral(@"

                            </tbody>
                        </table>
                    </div>
                </div>
                <div class=""col-lg-3"">
                    <h2 class=""title-1 m-b-25"">Top Servies</h2>
                    <div class=""au-card au-card--bg-blue au-card-top-countries m-b-40"">
                        <div class=""au-card-inner"">
                            <div class=""table-responsive"">
                                <table class=""table table-top-countries"">
                                    <tbody>
");
            EndContext();
#line 132 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                         foreach (var item in Model.Top10Services)
                                        {

#line default
#line hidden
            BeginContext(6371, 105, true);
            WriteLiteral("                                            <tr>\r\n                                                <td> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6476, "\"", 6516, 2);
            WriteAttributeValue("", 6483, "/Services/Details/", 6483, 18, true);
#line 135 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
WriteAttributeValue("", 6501, item.ServiceId, 6501, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6517, 22, true);
            WriteLiteral(" style=\"color:white;\">");
            EndContext();
            BeginContext(6540, 16, false);
#line 135 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                                                                                                 Write(item.ServiceName);

#line default
#line hidden
            EndContext();
            BeginContext(6556, 84, true);
            WriteLiteral("</a></td>\r\n                                                <td class=\"text-right\">£ ");
            EndContext();
            BeginContext(6641, 10, false);
#line 136 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                                                    Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(6651, 58, true);
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
            EndContext();
#line 138 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\CP\Index.cshtml"
                                        }

#line default
#line hidden
            BeginContext(6752, 525, true);
            WriteLiteral(@"

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""copyright"">
                        <p>Copyright © 2019 . All rights reserved.
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Vendi.App.Models.CPModelView> Html { get; private set; }
    }
}
#pragma warning restore 1591
