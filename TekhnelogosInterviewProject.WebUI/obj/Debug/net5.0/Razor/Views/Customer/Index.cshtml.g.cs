#pragma checksum "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "374cf04e39590d06f6b1979c14cc5dd8a426b4a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
using TekhnelogosInterviewProject.Entity.DTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"374cf04e39590d06f6b1979c14cc5dd8a426b4a8", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130f06a18e01cab7b2dc4f52cc0dd9524f90b050", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CustomerDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
  
    ViewData["Title"] = "Müşteri Listesi";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
   
    string statusColor = "";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Site wrapper -->
<div class=""wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Müşteri Listesi</h1>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">

        <!-- Default box -->
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Müşteri Listesi</h3>

                <div class=""card-tools"">
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                        <i class=""fas fa-minus""></i>
                    </button>
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" data-toggle=""tooltip"" title=""Remove"">
                       ");
            WriteLiteral(@" <i class=""fas fa-times""></i>
                    </button>
                </div>
            </div>
            <a href=""/Customer/AddCustomer/"" class=""btn btn-success"">
                <i class=""fas fa-plus""></i> Yeni Müşteri
            </a>

            <div class=""card-body p-0"">
                <table class=""table table-striped projects"">
                    <thead>
                        <tr>
                            <th style=""width: 5%"">
                                #
                            </th>
                            <th style=""width: 15%"">
                                Müşteri Adı
                            </th>
                            <th style=""width: 15%"">
                                Müşteri Soyadı
                            </th>
                            <th style=""width: 20%"">
                                Adres
                            </th>
                            <th style=""width: 15%"">
                                Duru");
            WriteLiteral("m\r\n                            </th>\r\n                            <th>\r\n\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 74 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                         foreach (var item in Model)
                        {

                            if (item.IsActive)
                            {
                                statusColor = "badge badge-success";
                            }
                            else
                            {
                                statusColor = "badge badge-danger";
                            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 88 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                               Write(item.CustomerId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 91 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                               Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 94 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                               Write(item.CustomerSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 97 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                               Write(item.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 3549, "\"", 3569, 1);
#nullable restore
#line 100 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
WriteAttributeValue("", 3557, statusColor, 3557, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 100 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                                                            Write(item.IsActive ? "Aktif":"Pasif");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n\r\n\r\n                                <td class=\"project-actions text-right\">\r\n");
#nullable restore
#line 105 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                                     if (item.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"btn btn-default btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 3900, "\"", 3939, 2);
            WriteAttributeValue("", 3907, "/Cargo/AddCargo/", 3907, 16, true);
#nullable restore
#line 107 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
WriteAttributeValue("", 3923, item.CustomerId, 3923, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <i class=\"fas fa-plus\">\r\n                                            </i>\r\n                                            Kargo İşlemleri\r\n                                        </a>\r\n");
#nullable restore
#line 112 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"btn btn-default btn-sm disabled\"");
            BeginWriteAttribute("href", " href=\"", 4371, "\"", 4410, 2);
            WriteAttributeValue("", 4378, "/Cargo/AddCargo/", 4378, 16, true);
#nullable restore
#line 115 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
WriteAttributeValue("", 4394, item.CustomerId, 4394, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <i class=\"fas fa-plus\">\r\n                                            </i>\r\n                                            Kargo İşlemleri\r\n                                        </a>\r\n");
#nullable restore
#line 120 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"btn btn-info btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 4745, "\"", 4791, 2);
            WriteAttributeValue("", 4752, "/Customer/EditCustomer/", 4752, 23, true);
#nullable restore
#line 121 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
WriteAttributeValue("", 4775, item.CustomerId, 4775, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                        Düzenle
                                    </a>
                                    <a class=""btn btn-danger btn-sm""");
            BeginWriteAttribute("href", " href=\"", 5071, "\"", 5119, 2);
            WriteAttributeValue("", 5078, "/Customer/DeleteCustomer/", 5078, 25, true);
#nullable restore
#line 126 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
WriteAttributeValue("", 5103, item.CustomerId, 5103, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        <i class=""fas fa-trash"">
                                        </i>
                                        Sil
                                    </a>
                                </td>


                            </tr>
");
#nullable restore
#line 135 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Customer\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n        <!-- /.card -->\r\n\r\n    </section>\r\n    <!-- /.content -->\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CustomerDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591