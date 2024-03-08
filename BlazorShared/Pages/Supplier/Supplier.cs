using Application.Suppliers.Commands;
using Application.Suppliers.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorShared.Pages.Supplier
{
    public partial class Supplier
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<Domain.Entities.Supplier>? Suppliers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Suppliers = await Mediator.Send(new GetSupplierListQuery());
        }

        private void Clicked()
        {

        }

        private async Task Add()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddSupplierDialog>("Thêm nhà cung cấp", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                await Mediator.Send(new InsertSupplierCommand((string)dialogResult.Data));
                IsSearching = true;
                Suppliers = await Mediator.Send(new GetSupplierListQuery());
                IsSearching = false;
            }
        }


    }
}
