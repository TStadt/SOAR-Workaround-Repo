#pragma checksum "C:\Users\keegan.moore\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ModifyAnnouncement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c24363968e44492ab4cd96d090b96b090e605c92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HMB.GAP2019.Intranet.UITemplates.Pages.Pages_ModifyAnnouncement), @"mvc.1.0.razor-page", @"/Pages/ModifyAnnouncement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c24363968e44492ab4cd96d090b96b090e605c92", @"/Pages/ModifyAnnouncement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eec557b70ace5c92a2386b230c719a3929f00441", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ModifyAnnouncement : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 2 "C:\Users\keegan.moore\source\repos\SOAR-Workaround-Repo\HMB.GAP2019.Intranet.UITemplates\Pages\ModifyAnnouncement.cshtml"
  
    ViewData["Title"] = "Modify Announcement";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<article>\r\n    <h2>Modify Announcements</h2>\r\n\r\n    <div>\r\n        <input class=\"form-check-input\" type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 210, "\"", 218, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"flexCheckDefault\">\r\n        <label class=\"form-check-label\" for=\"flexCheckDefault\">\r\n            High Priority?\r\n        </label>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c24363968e44492ab4cd96d090b96b090e605c923922", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col form-group"">
                    <label for=""formGroupExampleInput"">Start Date</label>
                    <input type=""date"" class=""form-control"" id=""formGroupStartDate"" placeholder=""Example input"">
                </div>
                <div class=""col form-group"">
                    <label for=""formGroupExampleInput"">End Date</label>
                    <input type=""date"" class=""form-control"" id=""formGroupEndDate"" placeholder=""Example input"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col form-group"">
                    <label for=""formGroupExampleInput"">Title</label>
                    <input type=""text"" class=""form-control"" id=""formGroupTitle"" placeholder=""Title"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col form-group"">
                    <label for=""formGroupExampleInput"">Body</label>
                  ");
                WriteLiteral(@"  <textarea class=""form-control"" id=""formGroupBody"" placeholder=""Text body""></textarea>
                </div>
            </div>
            <div class=""row"">
                <button type=""button"" class=""btn btn-info"">Save</button>
            </div>
        ");
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
            WriteLiteral("\r\n    </div>\r\n</article>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_ModifyAnnouncement> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_ModifyAnnouncement> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_ModifyAnnouncement>)PageContext?.ViewData;
        public Pages_ModifyAnnouncement Model => ViewData.Model;
    }
}
#pragma warning restore 1591
