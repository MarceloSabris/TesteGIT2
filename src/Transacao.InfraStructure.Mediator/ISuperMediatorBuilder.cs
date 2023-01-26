using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Transacao.InfraStructure.Common.Mediator
{
    public interface IMediatorBuilder
    {
        public IServiceCollection Services { get; }
        public Assembly[] Assemblies { get; }
    }
}
