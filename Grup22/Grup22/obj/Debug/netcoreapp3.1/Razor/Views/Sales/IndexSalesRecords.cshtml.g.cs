#pragma checksum "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d84bc36ec9cb2b21983191c365a6b2e2af753154"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sales_IndexSalesRecords), @"mvc.1.0.view", @"/Views/Sales/IndexSalesRecords.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d84bc36ec9cb2b21983191c365a6b2e2af753154", @"/Views/Sales/IndexSalesRecords.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"320e68ff9d49128fb11a7b21c53c498cce452133", @"/Views/_ViewImports.cshtml")]
    public class Views_Sales_IndexSalesRecords : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tuple<Grup22.Models.ProductSalesRecord, Grup22.Models.Product>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
  
    ViewData["Title"] = "Satış Kayıtları";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Satış Kayıtları</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Ürün İsmi\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
           Write(Html.DisplayNameFor(model => model.Item1.salesRecordAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            <th>
                Toplam Ödenen Ücret
            </th>
            <th>
                Sipariş Oluşturulma Tarihi
            </th>
            <th>
                Sipariş Tamamlanma Tarihi
            </th>
");
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item2.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item1.salesRecordAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 44 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
                      
                        var amount = item.Item1.salesRecordAmount;
                        var price = item.Item2.productPrice;
                        string totalPrice = (price * amount).ToString();
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 49 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
               Write(totalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item1.orderCreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
               Write(Html.DisplayFor(modelItem => item.Item1.orderCompletionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\EMRE\source\repos\atakankar\YZM-4215-GRUP-22\Grup22\Grup22\Views\Sales\IndexSalesRecords.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tuple<Grup22.Models.ProductSalesRecord, Grup22.Models.Product>>> Html { get; private set; }
    }
}
#pragma warning restore 1591