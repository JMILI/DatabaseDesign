#pragma checksum "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Errors\DepositoryExistError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "392c2a4ded740737db6de1672c782aa1c0717989"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Errors_DepositoryExistError), @"mvc.1.0.view", @"/Views/Errors/DepositoryExistError.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Errors/DepositoryExistError.cshtml", typeof(AspNetCore.Views_Errors_DepositoryExistError))]
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
#line 1 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\_ViewImports.cshtml"
using BankDepositUI;

#line default
#line hidden
#line 2 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\_ViewImports.cshtml"
using BankDepositUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392c2a4ded740737db6de1672c782aa1c0717989", @"/Views/Errors/DepositoryExistError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d72f1e3dd3694ecff2455f1272a630c42f4b317", @"/Views/_ViewImports.cshtml")]
    public class Views_Errors_DepositoryExistError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Errors\DepositoryExistError.cshtml"
  
    Layout = "_SignInLayout";

#line default
#line hidden
            BeginContext(38, 99, true);
            WriteLiteral("\r\n<h1 class=\"error\">错误 <strong></strong></h1>\r\n<h2 class=\"error\"> <strong>该储户账号已经存在</strong></h2>\r\n");
            EndContext();
            BeginContext(137, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9159adb7929646c8a0101823972cebb0", async() => {
                BeginContext(195, 124, true);
                WriteLiteral("\r\n    <div class=\"controls\">\r\n        <button class=\"btn btn-greensea\"><i class=\"fa fa-home\"></i>重新注册</button>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 7 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Errors\DepositoryExistError.cshtml"
AddHtmlAttributeValue("", 151, Url.Action("AddInformation","Depositors"), 151, 42, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
