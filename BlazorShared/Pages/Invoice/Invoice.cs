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
using Application.Invoices.Queries;
using BlazorShared.Pages.Invoice;
using Application.DTOs;

namespace BlazorShared.Pages.Invoice
{
    public partial class Invoice
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<InvoiceViewModel>? Invoices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Invoices = await Mediator.Send(new GetInvoiceListQuery());
        }

        private void Clicked()
        {

        }

        private async Task OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddInvoiceDialog>("Thêm phiếu nhập", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                IsSearching = true;
                Invoices = await Mediator.Send(new GetInvoiceListQuery());
                IsSearching = false;
            }
        }

        private async Task OpenEditDialog(int InvoiceId)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var parameters = new DialogParameters { ["InvoiceId"] = InvoiceId };
            var dialog = DialogService.Show<EditInvoiceDialog>("Chỉnh sửa phiếu nhập", parameters, options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                IsSearching = true;
                Invoices = await Mediator.Send(new GetInvoiceListQuery());
                IsSearching = false;
            }
        }

    }
}
