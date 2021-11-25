#pragma checksum "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12aa13c10e233bf4b511f9e342bfd24c24c69c51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cargo_EditCargo), @"mvc.1.0.view", @"/Views/Cargo/EditCargo.cshtml")]
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
#line 1 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\_ViewImports.cshtml"
using TekhnelogosInterviewProject.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\_ViewImports.cshtml"
using TekhnelogosInterviewProject.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12aa13c10e233bf4b511f9e342bfd24c24c69c51", @"/Views/Cargo/EditCargo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130f06a18e01cab7b2dc4f52cc0dd9524f90b050", @"/Views/_ViewImports.cshtml")]
    public class Views_Cargo_EditCargo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TekhnelogosInterviewProject.Entity.DTOs.CargoDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
  
    ViewData["Title"] = "Kargo Düzenleme Sayfası";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<h1>Kargo Düzenleme Sayfası</h1>\r\n<br />\r\n");
#nullable restore
#line 10 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
 using (Html.BeginForm("EditCargo", "Cargo", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\" style=\"width:800px;margin:auto\">\r\n    ");
#nullable restore
#line 13 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.Hidden("Kargo Id"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 14 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.HiddenFor(x => x.CargoId, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 15 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.Label("Kargo Adı"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 16 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.TextBoxFor(x => x.CargoName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <br />\r\n\r\n    ");
#nullable restore
#line 20 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.Label("Müşteri"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 21 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.DropDownListFor(x => x.CustomerId, (List<SelectListItem>)ViewBag.vlcCustomer, new { @class = "form-control", disabled = "disabled" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <br />\r\n\r\n    ");
#nullable restore
#line 25 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.Label("Personel"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 26 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.DropDownListFor(x => x.PersonalId, (List<SelectListItem>)ViewBag.vlcPersonal, "-Lütfen Seçiniz-", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <br />\r\n    ");
#nullable restore
#line 29 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.Label("Kargo Fiyatı"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 30 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
Write(Html.TextBoxFor(x => x.CargoPrice, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <br />\r\n    <button class=\"btn btn-info\">Teslim Et</button>\r\n</div>\r\n");
#nullable restore
#line 39 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Cargo\EditCargo.cshtml"
}

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TekhnelogosInterviewProject.Entity.DTOs.CargoDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
