#pragma checksum "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Managers\AddInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "002ca22ad4700693421bd2a0040375c49dba7d3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Managers_AddInformation), @"mvc.1.0.view", @"/Views/Managers/AddInformation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Managers/AddInformation.cshtml", typeof(AspNetCore.Views_Managers_AddInformation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"002ca22ad4700693421bd2a0040375c49dba7d3f", @"/Views/Managers/AddInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d72f1e3dd3694ecff2455f1272a630c42f4b317", @"/Views/_ViewImports.cshtml")]
    public class Views_Managers_AddInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onSubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return beforeSubmit(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Managers\AddInformation.cshtml"
  
    Layout = "_SignInLayout";

    ViewData["Title"] = "Home Page";

    //var user = Model;

#line default
#line hidden
            BeginContext(105, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(109, 1323, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97b1e5659294419eb6725bcda96ae6a7", async() => {
                BeginContext(260, 1165, true);
                WriteLiteral(@"
        <div class=""form-group"">
            <label for=""YourName"" class=""col-sm-4 control-label"">储户账号或电话号码</label>
            <div class=""col-sm-8"">
                <input type=""text"" class=""form-control colorpicker-element"" id=""colorpicker"" name=""Cuid"" value="""">
            </div>
        </div>
        <div class=""form-group"">
            <label for=""colorpicker-rgb"" class=""col-sm-4 control-label"">银行卡密码</label>
            <div class=""col-sm-8"">
                <input type=""password"" class=""form-control colorpicker-element"" id=""colorpicker-rgb"" name=""Cpassword"" value="""">
            </div>
        </div>
        <div class=""form-group"">
            <label for=""colorpicker-rgb"" class=""col-sm-4 control-label"">银行卡活期利率</label>
            <div class=""col-sm-8"">
                <input type=""text"" class=""form-control colorpicker-element"" id=""colorpicker-rgb"" name=""CflowBalanceRate"" value="""">
            </div>
        </div>
        <div class=""col-sm-offset-4 col-sm-8"">
            <button");
                WriteLiteral(" type=\"submit\" class=\"btn btn-greensea\">提交</button>\r\n            <button type=\"reset\" class=\"btn btn-red\">重新输入</button>\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 8 "F:\SoftOfJIMILI\Github\workspaceJM\C#web\DatabaseDesign\TheProgramSRC\DatabaseDesignOFBank\BankDeposit\BankDepositUI\Views\Managers\AddInformation.cshtml"
AddHtmlAttributeValue("", 186, Url.Action("AddLogin","Managers"), 186, 34, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1432, 542, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    function beforeSubmit(form) {
        if (form.Cuid.value == '') {
            alert('账号不能为空！');
            form.Cuid.focus();
            return false;
        }
        if (form.Cpassword.value == '') {
            alert('密码不能为空！');
            form.Cpassword.focus();
            return false;
        }
           if (form.CflowBalanceRate.value == '') {
            alert('利率不能为空！');
            form.CflowBalanceRate.focus();
            return false;
        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
