using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.Application.UseCase.Base
{
       public abstract class Handler<T> : IRequestHandler<T, Result>
        where T : Command<T>, new()
{
    public Result Result { get; set; }

    public string HandlerName => typeof(T).Name;

    protected Handler()
    {
        Result = new Result();
    }

    protected string GetFormattedException(Exception error)
    {
        var errors = new StringBuilder();
        errors.AppendLine($"{HandlerName} handlerError Internal Server Error")
           .AppendLine($"msg: {error.Message}")
           .AppendLine($"st: {error.StackTrace}")
           .AppendLine($"in: {error?.InnerException?.Message}");
        return errors.ToString();
    }

    public abstract Task<Result> Handle(T request, CancellationToken cancellationToken);

}
}

