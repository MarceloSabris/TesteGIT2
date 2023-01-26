using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Transacao.InfraStructure.Mediator;
using MediatR;
using Transacao.InfraStructure.Mediator.Model;

namespace Super.Common.Mediator.Logging
{
    public class LoggingMiddleware<TRequest> : LoggingMiddlewareBase, IHandlerMiddleware<TRequest>
         where TRequest : Transacao.InfraStructure.Mediator.IRequest
    {
        public LoggingMiddleware(ILogger<TRequest> logger) : base(logger)
        {
        }

        public async Task<IResult> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResult> next)
        {
            LogStart(request);
            try
            {
                var result = await next();

                LogFinished(request, result);

                return result;
            }
            catch (Exception ex)
            {
                LogException(request, ex);

                throw;
            }
        }

        public async Task<IResult> Handle(TRequest request, RequestHandlerDelegate<IResult> next, CancellationToken cancellationToken)
        {
            LogStart(request);
            try
            {
                var result =  await next();

                LogFinished(request, result);

                return result;
            }
            catch (Exception ex)
            {
                LogException(request, ex);

                throw;
            }
        }
    }
}
