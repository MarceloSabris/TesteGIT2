﻿using System;
using System.Runtime.Serialization;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.InfraStructure.Mediator
{
    public static class SuperModelExtensions
    {
        public static bool IsSuccessful(this IResult? result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return result.Error is null;
        }

        public static void EnsureSuccess(this IResult? result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (result.Error != null)
            {
                throw new FailedResultException(result.Error);
            }
        }

        public static Result AsResult(this IResult result)
        {
            if (result is Result typedResult)
            {
                return typedResult;
            }

            return result.Error != null
                ? new Result(result.Error)
                : new Result(result.Value);
        }

      
    }
    public class FailedResultException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //
        public Error Error { get; }

        public FailedResultException(Error error) : base($"Result was not successful. {error.Code}: '{error.Message}'")
        {
            Error = error;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected FailedResultException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
    }
}
