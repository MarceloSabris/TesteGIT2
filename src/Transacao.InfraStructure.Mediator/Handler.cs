using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.InfraStructure.Mediator
{
    public abstract class Handler< TRequest> : HandlerBase, IHandler<TRequest> where TRequest : Request
    {
        public abstract Task<Result> Handle(TRequest request, CancellationToken cancellationToken);

        async Task<IResult> IRequestHandler<TRequest, IResult>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Handle(request, cancellationToken);
            }
            catch (Exception exception)
            {
                return Result.Failure(HandleException(exception));
            }
        }

        protected static Result Success()
        {
            return Result.Success();
        }
    }
}
