#pragma checksum "C:\Users\keegan.moore\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ManageAnnouncements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ac2cd4f8a6263af3a18bd595d0447c50a8e496f"
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
#line 1 "C:\Users\keegan.moore\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\_ViewImports.cshtml"
using HMB.GAP2019.Intranet.UITemplates;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ac2cd4f8a6263af3a18bd595d0447c50a8e496f", @"/Pages/ManageAnnouncements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eec557b70ace5c92a2386b230c719a3929f00441", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ManageAnnouncements : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\keegan.moore\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ManageAnnouncements.cshtml"
  
    ViewData["Title"] = "Manage Announcements";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    .add-button-color {\r\n        color: white;\r\n        background-color: forestgreen;\r\n    }\r\n    .delete-button-color {\r\n        color: white;\r\n        background-color: red;\r\n    }\r\n</style>\r\n\r\n");
            WriteLiteral(@"
<h2>Announcements</h2>

<article>
    <h1>Manage your annoucements here.</h1>
    <button class=""add-button-color""
            formaction=""#"">Add</button>
    <div>
        <table class=""table table-responsive table-condensed table-striped"">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>High Priority</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            WriteLiteral(@"                <tr>
                    <td><a href=""#"">Good Luck on your presentation!</a></td>
                    <td>6/20/2018</td>
                    <td>6/22/2018</td>
                    <td>Yes</td>
                    <td>
                        <button class=""delete-button-color""
                                formaction=""#"">
                            Delete
                        </button>
                    </td>
                </tr>
                <tr>
                    <td><a href=""#"">Agile Essentials!</a></td>
                    <td>6/20/2018</td>
                    <td>6/22/2018</td>
                    <td>No</td>
                    <td>
                        <button class=""delete-button-color""
                                formaction=""#"">
                            Delete
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
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
