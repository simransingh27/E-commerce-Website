#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9626791756badf0093eb989507ac051aac3641f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductReviews), @"mvc.1.0.view", @"/Views/Shared/_ProductReviews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ProductReviews.cshtml", typeof(AspNetCore.Views_Shared__ProductReviews))]
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
#line 2 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
using Vendi.App.Models;

#line default
#line hidden
#line 3 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9626791756badf0093eb989507ac051aac3641f4", @"/Views/Shared/_ProductReviews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductReviews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vendi.Data.Review>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(152, 38, true);
            WriteLiteral("\r\n<h5> Customer Reviews</h5>\r\n<div >\r\n");
            EndContext();
#line 8 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
     foreach (var item in Model)
    {
        var user = await UserManager.FindByIdAsync(item.UserId);
        var fullname = user.FirstName + " " + user.LastName;

#line default
#line hidden
            BeginContext(359, 95, true);
            WriteLiteral("    <p class=\"jumbotron\" style=\"padding:15px;margin:10px;\">\r\n        <span>\r\n            <span>");
            EndContext();
            BeginContext(455, 8, false);
#line 14 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
             Write(fullname);

#line default
#line hidden
            EndContext();
            BeginContext(463, 66, true);
            WriteLiteral("</span><br />\r\n            <b>Rating: <span id=stars></span></b>\r\n");
            EndContext();
#line 16 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
              
                var num = item.Rating;
                for (var i = 0; i < num; i++)
                {

#line default
#line hidden
            BeginContext(651, 88, true);
            WriteLiteral("                    <i class=\"fa fa-star\" aria-hidden=\"true\" style=\"color: gold;\"></i>\r\n");
            EndContext();
#line 21 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
                }
            

#line default
#line hidden
            BeginContext(773, 36, true);
            WriteLiteral("        </span> \r\n        <span> In ");
            EndContext();
            BeginContext(810, 15, false);
#line 24 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
             Write(item.CreateDate);

#line default
#line hidden
            EndContext();
            BeginContext(825, 33, true);
            WriteLiteral("</span>\r\n        <br />\r\n        ");
            EndContext();
            BeginContext(859, 16, false);
#line 26 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
   Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(875, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 28 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Shared\_ProductReviews.cshtml"
    }

#line default
#line hidden
            BeginContext(894, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vendi.Data.Review>> Html { get; private set; }
    }
}
#pragma warning restore 1591
