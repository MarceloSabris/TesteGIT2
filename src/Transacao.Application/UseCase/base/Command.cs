
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.Application.UseCase.Base
{
    public abstract class Command<T> : Notifiable<Notification>,  IRequest<Result>
     where T : Command<T>
    , new()
    {
        private Error ErrorCode { get; set; }

        public virtual void DefaultErrorValidationResponse(Error errorCode) => ErrorCode = errorCode;
        public virtual Error GetErrorValidationResponse() => ErrorCode;

    }
}
