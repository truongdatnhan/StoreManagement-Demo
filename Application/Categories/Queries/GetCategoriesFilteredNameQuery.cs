using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries
{
    public record GetCategoriesFilteredNameQuery(string Name) : IRequest<List<Category>>;
}
