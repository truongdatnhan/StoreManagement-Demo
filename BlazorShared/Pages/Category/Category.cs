using Application.Categories.Commands;
using Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorShared.Pages.Category
{
    public partial class Category
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;
        private string? Search { get; set; }
        private bool IsSearching { get; set; }
        private List<Domain.Entities.Category>? Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Categories = await Mediator.Send(new GetCategoryListQuery());
        }

        private void Clicked()
        {

        }

        private async Task Add()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<AddCategoryDialog>("Thêm loại hàng", options);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                await Mediator.Send(new InsertCategoryCommand((string)dialogResult.Data));
                IsSearching = true;
                Categories = await Mediator.Send(new GetCategoryListQuery());
                IsSearching = false;
            }
        }


    }
}
