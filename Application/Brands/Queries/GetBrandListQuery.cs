﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Queries
{
    public record GetBrandListQuery() : IRequest<List<Brand>>;
}
