#pragma checksum "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Services\MyWork.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "755faf710f9c3a2cf2d50367195a069e913be391"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"755faf710f9c3a2cf2d50367195a069e913be391", @"/Views/Services/MyWork.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94808d38cdc2b238ca5fee90e2ba2b49d35994dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Services_MyWork : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
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
            BeginContext(103, 4653, true);
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
        <div class=""row"">
            <div class=""col-md-12"">
                <center>
                    <div>
                        <h4 id=""heading"">DIGITAL STOPWATCH</h4>
                        <h1 id=""timer"">0:0:0</h1>
                        <button class=""btn amado-btn mb-15"" id=""start"" onclick=""start();"">Start</button>
                        <button class=""btn amado-btn mb-15"" id=""stop"" onclick=""stop();"">Stop</button>
                        <button class=""btn amado-btn mb-15"" id=""reset"" onclick=""reset();"">Reset</button>
                        <button class=""btn amado-btn mb-15");
            WriteLiteral(@""" id=""finish"" onclick=""stop();"" data-toggle=""modal"" data-target=""#exampleModal"">Finish</button>
                    </div>
                </center>
            </div>






            <div class=""col-md-12"">
                <center>

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
            WriteLiteral(@"
                                    <div class=""form-group"">
                                        <label>Description</label>
                                        <textarea class=""form-control"" id=""descrp"" placeholder=""Description"" type=""text"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-sm""></textarea>
                                    </div>

                                    <div class=""form-group"">
                                        <label>Total Amount</label>
                                        <input class=""form-control"" id=""amount"" placeholder=""Total Amount"" type=""number"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-sm"" />
                                    </div>

                                </div>
                                <div class=""modal-footer"">

                                    <button onclick=""CompleteService()"" class=""btn amado-btn mb-15"">Complete</button>
                                </div>   ");
            WriteLiteral(@"                             
                            </div>
                        </div>
                    </div>
                    </center>
                </div>




</div>
    </div>


</div>


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
            miliSec = 0;
        }
        document.getElementById(""timer"").innerHTML = min + "":"" + sec;
    }


    function start() {
        document.getElementById(""start"").disabled = true;
        timer = setInterval(callTimer, 10);
    }

    function stop() {
        document.getElementById(""start"").disabled = false;
        clearInterv");
            WriteLiteral(@"al(timer);
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


        var res = validate();
        if (res === false) {
            return false;
        }


      

        var ServiceCompleteObj = {
            ServiceId: ");
            EndContext();
            BeginContext(4757, 5, false);
#line 160 "C:\Users\44782\Source\Repos\bluulabs-uk\vendi\Vendi.App\Views\Services\MyWork.cshtml"
                  Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(4762, 1431, true);
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

              
                    window.alert('Done');
                url = ""/Services/MyAppointments"";
                    $(location).attr(""href"", url);
                 //   location.reload();
                    //To My Appo
                 
            },
            error: function (errormessage) {
                alert(errormessage);
                location.reload();
            }
        });
    }



    function validate() {
        var isValid = true;
        if ($('#descrp').val().trim() === """") {
            $('#descrp').css('border-color', 'Red');
       ");
            WriteLiteral(@"     isValid = false;
        }
        else {
            $('#descrp').css('border-color', 'lightgrey');
        }
        if ($('#amount').val().trim() === """") {
            $('#amount').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#amount').css('border-color', 'lightgrey');
        }

        return isValid;
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
