#pragma checksum "C:\Users\anthony.huck\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ManageAnnouncements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c27d6d99347cc454a416baeb574e6507f6627ed5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HMB.GAP2019.Intranet.UITemplates.Pages.Pages_ManageAnnouncements), @"mvc.1.0.razor-page", @"/Pages/ManageAnnouncements.cshtml")]
namespace HMB.GAP2019.Intranet.UITemplates.Pages
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
#line 1 "C:\Users\anthony.huck\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\_ViewImports.cshtml"
using HMB.GAP2019.Intranet.UITemplates;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c27d6d99347cc454a416baeb574e6507f6627ed5", @"/Pages/ManageAnnouncements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eec557b70ace5c92a2386b230c719a3929f00441", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ManageAnnouncements : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\anthony.huck\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ManageAnnouncements.cshtml"
  
    ViewData["Title"] = "Manage Announcements";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<article class=""container-fluid"">
    <div class=""row"">
        <div class=""col"">
            <span class=""h2"">Announcements</span>
            <span class=""h2"">
                <a class=""btn btn-success btn-xs"" href=""#"" aria-label=""add announcement"">
                    Add
                </a>
            </span>
        </div>
    </div>
    <table class=""table table-responsive table-condensed table-striped"">
        <thead>
            <tr>
                <th>Title</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>High Priority</th>
                <th>&nbsp;</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><a href=""#"">Good Luck on your presentation!</a></td>
                <td>6/20/2018</td>
                <td>6/22/2018</td>
                <td>Yes</td>
                <td>
                    <button class=""btn btn-danger btn-xs"" aria-label=""remove announcement"">
                   ");
            WriteLiteral(@"     Delete
                    </button>
                </td>
            </tr>
            <tr>
                <td><a href=""#"">Git Basics</a></td>
                <td>6/11/2018</td>
                <td>6/22/2018</td>
                <td>No</td>
                <td>
                    <button class=""btn btn-danger btn-xs"" aria-label=""remove announcement"">
                        Delete
                    </button>
                </td>
            </tr>
        </tbody>
    </table>
</article>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_ManageAnnouncements> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_ManageAnnouncements> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_ManageAnnouncements>)PageContext?.ViewData;
        public Pages_ManageAnnouncements Model => ViewData.Model;
    }
}
#pragma warning restore 1591
