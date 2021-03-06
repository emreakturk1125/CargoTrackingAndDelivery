#pragma checksum "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ee266633a049f249da06fe4161aa9370806b064"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
#line 1 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
using TekhnelogosInterviewProject.Entity.DTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ee266633a049f249da06fe4161aa9370806b064", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130f06a18e01cab7b2dc4f52cc0dd9524f90b050", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RoleDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
  
    ViewData["Title"] = "Rol Listesi";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
  
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
                    <h1>Rol Listesi</h1>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">

        <!-- Default box -->
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Rol Listesi</h3>

                <div class=""card-tools"">
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                        <i class=""fas fa-minus""></i>
                    </button>
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" data-toggle=""tooltip"" title=""Remove"">
                        <i clas");
            WriteLiteral(@"s=""fas fa-times""></i>
                    </button>
                </div>
            </div>
            <a href=""/Role/AddRole/"" class=""btn btn-success"">
                <i class=""fas fa-plus""></i> Yeni Rol
            </a>

            <div class=""card-body p-0"">
                <table class=""table table-striped projects"">
                    <thead>
                        <tr>
                            <th style=""width: 5%"">
                                #
                            </th>
                            <th style=""width: 15%"">
                                Rol Ad??
                            </th> 
                            <th style=""width: 15%"">
                                Durum
                            </th>
                            <th>

                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 68 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
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
#line 82 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
                               Write(item.RoleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 85 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
                               Write(item.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>  \r\n                                <td>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 2976, "\"", 2996, 1);
#nullable restore
#line 88 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
WriteAttributeValue("", 2984, statusColor, 2984, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 88 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
                                                            Write(item.IsActive ? "Aktif":"Pasif");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n\r\n\r\n                                <td class=\"project-actions text-right\">\r\n                                    <a class=\"btn btn-info btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 3224, "\"", 3258, 2);
            WriteAttributeValue("", 3231, "/Role/EditRole/", 3231, 15, true);
#nullable restore
#line 93 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
WriteAttributeValue("", 3246, item.RoleId, 3246, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                        D??zenle
                                    </a>
                                    <a class=""btn btn-danger btn-sm""");
            BeginWriteAttribute("href", " href=\"", 3538, "\"", 3574, 2);
            WriteAttributeValue("", 3545, "/Role/DeleteRole/", 3545, 17, true);
#nullable restore
#line 98 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
WriteAttributeValue("", 3562, item.RoleId, 3562, 12, false);

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
#line 107 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Role\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RoleDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
