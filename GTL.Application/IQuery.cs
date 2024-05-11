using GTL.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
    }
}
