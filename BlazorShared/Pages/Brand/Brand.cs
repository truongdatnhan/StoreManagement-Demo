using Application.Brands.Commands;
using Application.Brands.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorShared.Pages.Brand
{
    public partial class Brand
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<Domain.Entities.Brand>? Brands { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Brands = await Mediator.Send(new GetBrandListQuery());
        }

        private void Clicked()
        {

        }

        private async Task Add()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddBrandDialog>("Thêm thương hiệu", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                await Mediator.Send(new InsertBrandCommand((string)dialogResult.Data));
                IsSearching = true;
                Brands = await Mediator.Send(new GetBrandListQuery());
                IsSearching = false;
            }
        }


    }
}
