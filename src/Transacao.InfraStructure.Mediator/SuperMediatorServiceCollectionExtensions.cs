using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using Super.Common.Mediator;
using Transacao.InfraStructure.Mediator;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatorServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, IEnumerable<Assembly> assemblies,
            Action<IMediatorBuilder>? configure = null)
        {
            var arr = assemblies.ToArray();

            services.AddMediatR(arr);

            var builder = new MediatorBuilder(services, arr);

            builder.UseLogging();

            configure?.Invoke(builder);

           

            return services;
        }
    }
}
