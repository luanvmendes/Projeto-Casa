#pragma checksum "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb03372ba3d211fdb3c0ed0d50123a235cac8af5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\_ViewImports.cshtml"
using CasaShow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\_ViewImports.cshtml"
using CasaShow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb03372ba3d211fdb3c0ed0d50123a235cac8af5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6768e84646838318e7bc5a37923e6f95d524d7d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CasaShow.Models.Evento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "<!-- Bilheteria -->";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Slide Eventos-->
<section class=""carousel slide"" id=""slide-eventos"">
    <div class=""full-screen"">
        <div class=""slide carousel"" data-ride=""carousel"">
            <ol class=""carousel-indicators"">
                <li data-target=""#slide-eventos"" data-slide-to=""0"" class=""active""></li>
                <li data-target=""#slide-eventos"" data-slide-to=""1""></li>
                <li data-target=""#slide-eventos"" data-slide-to=""2""></li>
                </ol>
                <div class=""carousel-inner"">
                    <div class=""carousel-item slider-fullscreen-image active"" style=""background-image: url(img/eventos/kiss.jpg);"">
                    <div class=""container container-slide"">
                        <div class=""image_wrapper"">
                            <div class=""mbr-overlay"" style=""background-color: rgb(70, 80, 82);""></div>
                            <img src=""img/eventos/kiss.jpg"">
                            <div class=""carousel-caption d-block"">
                         ");
            WriteLiteral(@"       <h5>KISS</h5>
                                <p>Data:</p>
                                <a class=""btn  btn-warning display-4"" href=""#"">COMPRAR INGRESSO</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""carousel-item slider-fullscreen-image"" style=""background-image: url(img/eventos/metallica.jpg);"">
                    <div class=""container container-slide"">
                        <div class=""image_wrapper"">
                            <div class=""mbr-overlay"" style=""background-color: rgb(35, 35, 35);""></div>
                            <img src=""img/eventos/metallica.jpg"">
                            <div class=""carousel-caption d-block"">
                                <a class=""btn  btn-warning display-4"" href=""#"">COMPRAR INGRESSO</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""carous");
            WriteLiteral(@"el-item slider-fullscreen-image"" style=""background-image: url(img/eventos/nightwish.jpg);"">
                    <div class=""container container-slide"">
                        <div class=""image_wrapper"">
                            <div class=""mbr-overlay"" style=""background-color: rgb(70, 80, 82);""></div>
                            <img src=""img/eventos/nightwish.jpg"">
                            <div class=""carousel-caption d-block"">
                                <a class=""btn  btn-warning display-4"" href=""#"">COMPRAR INGRESSO</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <a class=""carousel-control carousel-control-prev"" href=""#slide-eventos"" role=""button"" data-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Previous</span>
            </a>
            <a class=""carousel-control-next"" href=""#slide-eve");
            WriteLiteral(@"ntos"" role=""button"" data-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>
    </div>
</section>
<!-- Seção ingressos-->
");
#nullable restore
#line 64 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
 if (Model.Count() != 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"ingressos\">\r\n        <div class=\"title\">\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 3538, "\"", 3546, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h1>PRÓXIMOS SHOWS</h1>\r\n                <p class=\"text-white\"></p>\r\n            </div>\r\n        </div>\r\n        <div class=\"col tickets\">\r\n");
#nullable restore
#line 73 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
             foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row ticket"">
                    <div class=""col"">
                        <div class=""row"">
                            <a class=""col-10 ticket-link"" href=""05-Events-Single-Events.html"">
                                <div class=""day"">
                                    <div class=""day_num"">
                                        <span>");
#nullable restore
#line 80 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
                                         Write(String.Format("{0:dd}", item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <div>\r\n                                            <p>");
#nullable restore
#line 82 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
                                          Write(String.Format("{0:MMM}", item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>");
#nullable restore
#line 83 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
                                          Write(String.Format("{0:yyyy}", item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"name\">\r\n                                    <p><span>");
#nullable restore
#line 88 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
                                        Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> // <span>");
#nullable restore
#line 88 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
                                                                                                 Write(Html.DisplayFor(modelItem => item.CasaShow.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></p>
                                </div>
                            </a>
                            <div class=""col-2 buy"">
                                <a href=""#"">Buy Ticket</a>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 97 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </section>\r\n");
#nullable restore
#line 100 "C:\Users\Luan\Desktop\projetos\CasaDeShows\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CasaShow.Models.Evento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
