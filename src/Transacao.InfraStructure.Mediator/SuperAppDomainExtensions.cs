using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class AppDomainExtensions
    {
        public static Assembly[] GetLoadedAssemblies(this AppDomain domain)
        {
            var superAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName?.StartsWith("Transacao") == true)
                .ToArray();

            return superAssemblies;
        }
    }
}