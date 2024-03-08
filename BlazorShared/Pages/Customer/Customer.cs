using Application.Customers.Commands;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorShared.Pages.Customer
{
    public partial class Customer
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<Domain.Entities.Customer>? Customers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = await Mediator.Send(new GetCustomerListQuery());
        }

        private void Clicked()
        {

        }

        private async Task Add()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddCustomerDialog>("Thêm khách hàng", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                await Mediator.Send(new InsertCustomerCommand((string)dialogResult.Data));
                IsSearching = true;
                Customers = await Mediator.Send(new GetCustomerListQuery());
                IsSearching = false;
            }
        }


    }
}
