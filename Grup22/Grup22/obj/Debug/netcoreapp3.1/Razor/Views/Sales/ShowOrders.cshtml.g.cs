#pragma checksum "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41961a78e145427672290e0ea84026beeac173db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sales_ShowOrders), @"mvc.1.0.view", @"/Views/Sales/ShowOrders.cshtml")]
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
#line 1 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\_ViewImports.cshtml"
using Grup22;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\_ViewImports.cshtml"
using Grup22.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41961a78e145427672290e0ea84026beeac173db", @"/Views/Sales/ShowOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"320e68ff9d49128fb11a7b21c53c498cce452133", @"/Views/_ViewImports.cshtml")]
    public class Views_Sales_ShowOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tuple<Grup22.Models.ProductSalesRecord, Grup22.Models.Product>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
  
    ViewData["Title"] = "????lemdeki Sipari??ler";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>????lemdeki Sipari??ler</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ??r??n Ad??\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.Item1.salesRecordAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ??r??n??n Birim Fiyat??\r\n            </th>\r\n            <th>\r\n                    Toplam Tutar\r\n                </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item2.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item1.salesRecordAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item2.productPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 44 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
                          
                            var amount = item.Item1.salesRecordAmount;
                            var price = item.Item2.productPrice;
                            string totalPrice = (price * amount).ToString();
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 49 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
               Write(totalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                    </td>\r\n                <td>\r\n");
#nullable restore
#line 52 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
                     if (HttpContextAccessor.HttpContext.Session.GetInt32("isFactory") == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"btn-group btn-group-lg\"");
            BeginWriteAttribute("style", " style=\"", 1738, "\"", 1746, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <button type=\"button\" class=\"btn btn-default\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1823, "\"", 1899, 4);
            WriteAttributeValue("", 1833, "window.location.href=", 1833, 21, true);
            WriteAttributeValue(" ", 1854, "\'/Sales/EditOrder/", 1855, 19, true);
#nullable restore
#line 55 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
WriteAttributeValue("", 1873, item.Item1.salesRecordId, 1873, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1898, "\'", 1898, 1, true);
            EndWriteAttribute();
            WriteLiteral(">D??zenle</button>\r\n                            <button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1991, "\"", 2069, 4);
            WriteAttributeValue("", 2001, "window.location.href=", 2001, 21, true);
            WriteAttributeValue(" ", 2022, "\'/Sales/DeleteOrder/", 2023, 21, true);
#nullable restore
#line 56 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
WriteAttributeValue("", 2043, item.Item1.salesRecordId, 2043, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2068, "\'", 2068, 1, true);
            EndWriteAttribute();
            WriteLiteral(">??ptal Et</button>\r\n                        </div>\r\n");
#nullable restore
#line 58 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
                    }
                    else if (HttpContextAccessor.HttpContext.Session.GetInt32("isFactory") == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"btn-group btn-group-lg\">\r\n                            <button type=\"button\" class=\"btn btn-default\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2401, "\"", 2477, 4);
            WriteAttributeValue("", 2411, "window.location.href=", 2411, 21, true);
            WriteAttributeValue(" ", 2432, "\'/Sales/EditOrder/", 2433, 19, true);
#nullable restore
#line 62 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
WriteAttributeValue("", 2451, item.Item1.salesRecordId, 2451, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2476, "\'", 2476, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Detay</button>\r\n                            <button type=\"button\" class=\"btn btn-success\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2568, "\"", 2646, 4);
            WriteAttributeValue("", 2578, "window.location.href=", 2578, 21, true);
            WriteAttributeValue(" ", 2599, "\'/Sales/AcceptOrder/", 2600, 21, true);
#nullable restore
#line 63 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
WriteAttributeValue("", 2620, item.Item1.salesRecordId, 2620, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2645, "\'", 2645, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Onayla</button>\r\n                            <button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2737, "\"", 2815, 4);
            WriteAttributeValue("", 2747, "window.location.href=", 2747, 21, true);
            WriteAttributeValue(" ", 2768, "\'/Sales/RejectOrder/", 2769, 21, true);
#nullable restore
#line 64 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
WriteAttributeValue("", 2789, item.Item1.salesRecordId, 2789, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2814, "\'", 2814, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Reddet</button>\r\n                        </div>\r\n");
#nullable restore
#line 66 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 69 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\ShowOrders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tuple<Grup22.Models.ProductSalesRecord, Grup22.Models.Product>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
