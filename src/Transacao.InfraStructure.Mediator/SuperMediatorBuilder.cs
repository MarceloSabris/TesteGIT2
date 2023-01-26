using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Transacao.InfraStructure.Mediator
{
    internal class MediatorBuilder : IMediatorBuilder
    {
        public IServiceCollection Services { get; }
        public Assembly[] Assemblies { get; }

        public MediatorBuilder(IServiceCollection services, Assembly[] assemblies)
        {
            Services = services;
            Assemblies = assemblies;
        }
    }
}
