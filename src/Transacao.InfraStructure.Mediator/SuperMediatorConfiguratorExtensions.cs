﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Transacao.InfraStructure.Mediator;
using Transacao.InfraStructure.Mediator.Model;
using Super.Common.Mediator.Logging;



// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatorConfiguratorExtensions
    {
        public static IMediatorBuilder AddGenericMiddleware(this IMediatorBuilder builder, Type middlewareType)
        {
            var genericParameterCount = ((TypeInfo)middlewareType).GenericTypeParameters.Length;

            if (genericParameterCount == 2)
            {
                foreach (var (requestType, resultType) in builder.Assemblies.SelectMany(a => a.GetTypes())
                    .Select(type => (type, type.GetInterfaces()
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(MediatR.IRequest<>))
                        .SelectMany(i => i.GetGenericArguments())
                        .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IResult))))
                    .Where(x => !x.type.IsAbstract && x.Item2 != null)
                    .ToArray())
                {
                    var serviceType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType,
                        resultType);

                    Debug.Assert(resultType != null, nameof(resultType) + " != null");

                    var requestEntityResultPipelineBehavior = middlewareType.MakeGenericType(requestType, resultType.GetGenericArguments()[0]);
                    builder.Services.TryAddEnumerable(new ServiceDescriptor(serviceType, requestEntityResultPipelineBehavior, ServiceLifetime.Transient));
                }

                return builder;
            }

            if (genericParameterCount == 1)
            {
                foreach (var (requestType, resultType) in builder.Assemblies.SelectMany(a => a.GetTypes())
                    .Select(type => (type, type.GetInterfaces()
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(MediatR.IRequest<>))
                        .SelectMany(i => i.GetGenericArguments())
                        .FirstOrDefault(x => x == typeof(IResult))))
                    .Where(x => !x.type.IsAbstract && x.Item2 != null)
                    .ToArray())
                {
                    var serviceType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType,
                        resultType);

                    Debug.Assert(resultType != null, nameof(resultType) + " != null");

                    var requestEntityResultPipelineBehavior = middlewareType.MakeGenericType(requestType);
                    builder.Services.TryAddEnumerable(new ServiceDescriptor(serviceType, requestEntityResultPipelineBehavior, ServiceLifetime.Transient));
                }

                return builder;
            }

            throw new ArgumentException("Invalid middleware type passed, you must pass an open generics type like, ex: typeof(YourMiddleware<,>)");
        }

        public static IMediatorBuilder UseLogging(this IMediatorBuilder builder)
        {
            builder.AddGenericMiddleware(typeof(LoggingMiddleware<>));
           

            return builder;
        }

      
    }
}
