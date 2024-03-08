﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Commands
{
    public record InsertBrandCommand(string Name) : IRequest<int>;
}
