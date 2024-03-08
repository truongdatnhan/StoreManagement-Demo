using Application.DTOs;
using Application.Products.Commands;
using Application.Products.Queries;
using BlazorShared.Pages.Order;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorShared.Pages.Product
{
    public partial class Product
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<ProductViewModel>? Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await Mediator.Send(new GetProductListQuery());
        }

        private void Clicked()
        {

        }

        private async Task OpenProductDialog(int productId = 0)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters { ["ProductId"] = productId };
            string title;
            if (productId != 0)
            {
                title = "Sửa chi mặt hàng";
            }
            else
            {
                title = "Thêm mặt hàng";
            }
            var dialog = DialogService.Show<ProductDialog>(title, parameters, options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                IsSearching = true;
                Products = await Mediator.Send(new GetProductListQuery());
                IsSearching = false;
            }
        }


    }
}
