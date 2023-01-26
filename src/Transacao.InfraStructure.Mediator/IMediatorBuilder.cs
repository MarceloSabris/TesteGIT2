using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Transacao.InfraStructure.Mediator
{

    public interface IMediatorBuilder
    {
        public IServiceCollection Services { get; }
        public Assembly[] Assemblies { get; }
    }
}
