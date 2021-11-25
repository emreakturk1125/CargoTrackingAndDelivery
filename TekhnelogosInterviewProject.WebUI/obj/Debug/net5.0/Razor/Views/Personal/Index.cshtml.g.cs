#pragma checksum "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9dadec61d499cdb5f19f49784970435c9f5f97e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personal_Index), @"mvc.1.0.view", @"/Views/Personal/Index.cshtml")]
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
#line 1 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
using TekhnelogosInterviewProject.Entity.DTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9dadec61d499cdb5f19f49784970435c9f5f97e", @"/Views/Personal/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130f06a18e01cab7b2dc4f52cc0dd9524f90b050", @"/Views/_ViewImports.cshtml")]
    public class Views_Personal_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PersonalWithRoleDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
  
    ViewData["Title"] = "Personel Listesi";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
  
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
                    <h1>Personel Listesi</h1>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">

        <!-- Default box -->
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Personel Listesi</h3>

                <div class=""card-tools"">
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                        <i class=""fas fa-minus""></i>
                    </button>
                    <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" data-toggle=""tooltip"" title=""Remove"">
                     ");
            WriteLiteral(@"   <i class=""fas fa-times""></i>
                    </button>
                </div>
            </div>
            <a href=""/Personal/AddPersonal/"" class=""btn btn-success"">
                <i class=""fas fa-plus""></i> Yeni Personel
            </a>

            <div class=""card-body p-0"">
                <table class=""table table-striped projects"">
                    <thead>
                        <tr>
                            <th style=""width: 5%"">
                                #
                            </th>
                            <th style=""width: 15%"">
                                Personel Adı
                            </th>
                            <th style=""width: 15%"">
                                Personel Soyadı
                            </th>
                            <th style=""width: 20%"">
                                Kullanıcı Adı
                            </th> 
                            <th style=""width: 15%"">
                      ");
            WriteLiteral(@"          Rol
                            </th>
                            <th style=""width: 5%"">
                                Durumu
                            </th>
                            <th>

                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 77 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
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
#line 91 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                               Write(item.PersonalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 94 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                               Write(item.PersonalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 97 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                               Write(item.PersonalSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 100 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td> \r\n                                <td>\r\n                                    ");
#nullable restore
#line 103 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                               Write(item.Role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td> \r\n                                <td>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 3826, "\"", 3846, 1);
#nullable restore
#line 106 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
WriteAttributeValue("", 3834, statusColor, 3834, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 106 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
                                                            Write(item.IsActive ? "Aktif":"Pasif");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n\r\n\r\n                                <td class=\"project-actions text-right\">\r\n                                    <a class=\"btn btn-info btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 4074, "\"", 4120, 2);
            WriteAttributeValue("", 4081, "/Personal/EditPersonal/", 4081, 23, true);
#nullable restore
#line 111 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
WriteAttributeValue("", 4104, item.PersonalId, 4104, 16, false);

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
            BeginWriteAttribute("href", " href=\"", 4400, "\"", 4448, 2);
            WriteAttributeValue("", 4407, "/Personal/DeletePersonal/", 4407, 25, true);
#nullable restore
#line 116 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
WriteAttributeValue("", 4432, item.PersonalId, 4432, 16, false);

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
#line 125 "D:\Tekhnelogos\TekhnelogosInterviewProject\TekhnelogosInterviewProject.WebUI\Views\Personal\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PersonalWithRoleDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
