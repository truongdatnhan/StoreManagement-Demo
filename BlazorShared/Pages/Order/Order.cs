using Application.Orders.Queries;
using Application.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.DTOs;

namespace BlazorShared.Pages.Order
{
    public partial class Order
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<OrderViewModel>? Orders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Orders = await Mediator.Send(new GetOrderListQuery());
        }

        private void Clicked()
        {

        }

        private async Task OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddOrderDialog>("Thêm toa hàng", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                IsSearching = true;
                Orders = await Mediator.Send(new GetOrderListQuery());
                IsSearching = false;
            }
        }

        private async Task OpenEditDialog(int OrderId)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters { ["OrderId"] = OrderId };
            var dialog = DialogService.Show<EditOrderDialog>("Chỉnh sửa toa hàng", parameters, options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                IsSearching = true;
                Orders = await Mediator.Send(new GetOrderListQuery());
                IsSearching = false;
            }
        }

    }
}
