#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Services\MyWork.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40cdd1546371f2b1a390a957f866dfb44c84997b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services_MyWork), @"mvc.1.0.view", @"/Views/Services/MyWork.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Services/MyWork.cshtml", typeof(AspNetCore.Views_Services_MyWork))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40cdd1546371f2b1a390a957f866dfb44c84997b", @"/Views/Services/MyWork.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Services_MyWork : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(12, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Services\MyWork.cshtml"
  
    ViewData["Title"] = "MyWork";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(103, 1959, true);
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

    div {
        margin: 10px;
    }

    #timer {
        font-size: 2.5em;
    }
   
</style>

<div class=""single-product-area section-padding-100 clearfix"">
    <div class=""container-fluid"">
        <center>
            <div>
                <h4 id=""heading"">DIGITAL STOPWATCH</h4>
                <h1 id=""timer"">0:0:0</h1>
                <button class=""btn amado-btn mb-15"" id=""start"" onclick=""start();"">Start</button>
                <button class=""btn amado-btn mb-15"" id=""stop"" onclick=""stop();"">Stop</button>
                <button class=""btn amado-btn mb-15"" id=""reset"" onclick=""reset();"">Reset</button>
                <button class=""btn amado-btn mb-15"" id=""finish"" onclick=""stop();"" data-toggle=""modal"" data-target=""#exampleModal"">Finish</button>
            </div>
      ");
            WriteLiteral(@"  </center>
    </div>
</div>

<div class=""single-product-area section-padding-100 clearfix"">
    <div class=""container-fluid"">
        <div>
            <div>
                <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                    <div class=""modal-dialog"" role=""document"">
                        <div class=""modal-content"">
                            <div class=""modal-header"">
                                <h5 class=""modal-title"" id=""exampleModalLabel"">Enter Details</h5>
                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                    <span aria-hidden=""true"">&times;</span>
                                </button>
                            </div>
                            <div class=""modal-body"">
                                ");
            EndContext();
            BeginContext(2062, 805, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40cdd1546371f2b1a390a957f866dfb44c84997b5737", async() => {
                BeginContext(2068, 792, true);
                WriteLiteral(@"
                                    <div class=""form-group"">
                                        <label>Description</label>
                                        <textarea class=""form-control"" id=""descrp"" placeholder=""Description"" type=""text"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-sm""></textarea>
                                    </div>

                                    <div class=""form-group"">
                                        <label>Total Amount</label>
                                        <input class=""form-control"" id=""amount"" placeholder=""Total Amount"" type=""number"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-sm"" />
                                    </div>
                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2867, 1816, true);
            WriteLiteral(@"
                            </div>
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn amado-btn mb-15"" data-dismiss=""modal"">Close</button>
                                <button type=""submit"" onclick=""CompleteService()"" class=""btn amado-btn mb-15"">Complete</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script type=""text/javascript"">





</script>




<script type=""text/javascript"">

    var min = 0;
    var sec = 0;
    var miliSec = 0;
    var timer;

    function callTimer() {
        miliSec++;
        if (miliSec < 100) {
            if (miliSec === 99) {
                miliSec = 0;
                sec++;
                if (sec === 60) {
                    sec = 0;
                    min++;
                }
            }
        }
        else {
        ");
            WriteLiteral(@"    miliSec = 0;
        }
        document.getElementById(""timer"").innerHTML = min + "":"" + sec;
    }


    function start() {
        document.getElementById(""start"").disabled = true;
        timer = setInterval(callTimer, 10);
    }

    function stop() {
        document.getElementById(""start"").disabled = false;
        clearInterval(timer);
    }

    function reset() {
        stop();
        min = 0;
        sec = 0;
        miliSec = 0;
        document.getElementById(""timer"").innerHTML = min + "":"" + sec;
        document.getElementById(""start"").disabled = false;
    }

    function CompleteService() {

        stop();
        var c = $('#timer').html();
        var d = c.toString();

        var ServiceCompleteObj = {
            ServiceId: ");
            EndContext();
            BeginContext(4684, 5, false);
#line 147 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Services\MyWork.cshtml"
                  Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(4689, 753, true);
            WriteLiteral(@",
            TotalAmount: $('#amount').val(),
            Description: $('#descrp').val(),
            TimeTaken: d
        };

        $.ajax({
            url: ""/Services/CompleteServiceOffer"",
            data: JSON.stringify(ServiceCompleteObj),
            type: ""POST"",
            contentType: ""application/json;charset=utf-8"",
            dataType: ""json"",

            success: function (result) {

                if (result == true) {
                    window.alert('Done');
                    location.reload();
                }
            },
            error: function (errormessage) {
                alert(errormessage);
                location.reload();
            }
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
