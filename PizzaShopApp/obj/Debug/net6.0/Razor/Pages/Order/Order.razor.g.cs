#pragma checksum "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "247cc36123ffdbb115103da3beadd394cfee65dd"
// <auto-generated/>
#pragma warning disable 1591
namespace PizzaShopApp.Pages.Order
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using PizzaShopApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\_Imports.razor"
using PizzaShopApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
using PizzaShopApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Order")]
    public partial class Order : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Order</h1>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.AddMarkupContent(3, "<div class=\"col-md-6\"><a href=\'/Order/add\' class=\"btn btn-primary\" role=\"button\"><i class=\"fas fa-user-plus\"></i>\r\n            Add Order\r\n        </a></div>\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "input-group col");
            __builder.OpenElement(6, "input");
            __builder.AddAttribute(7, "type", "text");
            __builder.AddAttribute(8, "class", "form-control");
            __builder.AddAttribute(9, "placeholder", "Search user by id");
            __builder.AddAttribute(10, "onkeyup", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                                                                    FilterUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                      SearchString

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SearchString = __value, SearchString));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 18 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
         if (SearchString.Length > 0)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "input-group-append");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "class", "btn btn-danger");
            __builder.AddAttribute(17, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                                                         ResetSearch

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(18, "<i class=\"fas fa-times\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n<br>");
#nullable restore
#line 29 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
 if (FakturaList == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(20, "<p><em>Loading...</em></p>");
#nullable restore
#line 32 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(21, "table");
            __builder.AddAttribute(22, "class", "table table-striped align-middle table-bordered");
            __builder.AddMarkupContent(23, "<thead class=\"table-success\"><tr><th>Id</th>\r\n                <th>Username</th>\r\n                <th>Time of Order</th>\r\n                <th>Total Price</th>\r\n                <th>Pizza Name</th>\r\n                <th>Ingredients</th></tr></thead>\r\n        ");
            __builder.OpenElement(24, "tbody");
#nullable restore
#line 47 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
             foreach (var order in FakturaList)
            {
                var current = 0;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(25, "tr");
            __builder.OpenElement(26, "td");
#nullable restore
#line (51,26)-(51,34) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(27, order.Id);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                    ");
            __builder.OpenElement(29, "td");
#nullable restore
#line (52,26)-(52,40) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(30, order.Username);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                    ");
            __builder.OpenElement(32, "td");
#nullable restore
#line (53,26)-(53,45) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(33, order.Time_of_Order);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                    ");
            __builder.OpenElement(35, "td");
#nullable restore
#line (54,26)-(54,43) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(36, order.Total_Price);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                    ");
            __builder.OpenElement(38, "td");
            __builder.OpenElement(39, "select");
            __builder.AddAttribute(40, "class", "selectpicker");
#nullable restore
#line 57 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                             for (var i = 0; i < order.Pizzas.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(41, "option");
            __builder.AddAttribute(42, "value", 
#nullable restore
#line 59 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                                                i

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line (59,53)-(59,79) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(43, order.Pizzas[i].Pizza_Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 60 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                        ");
            __builder.OpenElement(45, "td");
#nullable restore
#line (64,30)-(64,64) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(46, order.Pizzas[current].Ingredient_1);

#line default
#line hidden
#nullable disable
            __builder.AddContent(47, ", ");
#nullable restore
#line (64,67)-(64,101) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(48, order.Pizzas[current].Ingredient_2);

#line default
#line hidden
#nullable disable
            __builder.AddContent(49, ", ");
#nullable restore
#line (64,104)-(64,138) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(50, order.Pizzas[current].Ingredient_3);

#line default
#line hidden
#nullable disable
            __builder.AddContent(51, ", ");
#nullable restore
#line (64,141)-(64,175) 25 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
__builder.AddContent(52, order.Pizzas[current].Ingredient_4);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                        ");
            __builder.OpenElement(54, "td");
            __builder.OpenElement(55, "a");
            __builder.AddAttribute(56, "href", "/order/edit/" + (
#nullable restore
#line 66 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                                              order.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(57, "class", "btn btn-outline-dark");
            __builder.AddAttribute(58, "role", "button");
            __builder.AddMarkupContent(59, "\r\n                            Edit\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n                        ");
            __builder.OpenElement(61, "button");
            __builder.AddAttribute(62, "class", "btn btn-outline-danger");
            __builder.AddAttribute(63, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 69 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
                                                                          () => DeleteConfirm(order.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(64, "\r\n                            Delete\r\n                        ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 74 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 78 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 79 "C:\Users\Hakan\source\repos\PizzaShopApp\PizzaShopApp\Pages\Order\Order.razor"
       
    private List<FakturaModel> FakturaList = new List<FakturaModel>();
    private List<FakturaModel> FakturaSearchList = new List<FakturaModel>();
   // private FakturaModel order = new FakturaModel();
    private string SearchString { get; set; } = string.Empty;
    protected override async Task OnInitializedAsync()
    {
        Http.BaseAddress = new Uri("https://localhost:7012/");
        await GetFakturas();
    }
    private async Task GetFakturas()
    {
         JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

        
        FakturaList = await Http.GetFromJsonAsync<List<FakturaModel>>("api/Order", options);


        FakturaSearchList = FakturaList;
    }
    private void FilterUser()
    {
        if (!string.IsNullOrEmpty(SearchString))
        {
            FakturaList = FakturaSearchList
                .Where(x => x.Username.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                .ToList();
        }
        else
        {
            FakturaList = FakturaSearchList;
        }
    }
    private void DeleteConfirm(int Id)
    {
        Http.DeleteAsync($"api/Order?id={Id}");
    }
    public void ResetSearch()
    {
        SearchString = string.Empty;
        FakturaList = FakturaSearchList;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
