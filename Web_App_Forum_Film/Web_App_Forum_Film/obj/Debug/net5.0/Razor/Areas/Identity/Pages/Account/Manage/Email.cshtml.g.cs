#pragma checksum "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\Account\Manage\Email.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "334710e5c3aec8b8b6e81cfd646baa62353476de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_Email), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/Email.cshtml")]
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
#nullable restore
#line 1 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\_ViewImports.cshtml"
using Web_App_Forum_Film.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\_ViewImports.cshtml"
using Web_App_Forum_Film.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Web_App_Forum_Film.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Web_App_Forum_Film.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"334710e5c3aec8b8b6e81cfd646baa62353476de", @"/Areas/Identity/Pages/Account/Manage/Email.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b8730dd5186b7ec89e09968009699d0444d4922", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f4cc3bef237177abde60dc50f3cd950f74daee3", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daec152c795b996238e94e84d0cf228ab5c706a9", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_Email : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\andrea\Source\Repos\Forum_Film\Web_App_Forum_Film\Web_App_Forum_Film\Areas\Identity\Pages\Account\Manage\Email.cshtml"
  
    ViewData["Title"] = "Manage Email";
    ViewData["ActivePage"] = ManageNavPages.Email;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EmailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EmailModel>)PageContext?.ViewData;
        public EmailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
