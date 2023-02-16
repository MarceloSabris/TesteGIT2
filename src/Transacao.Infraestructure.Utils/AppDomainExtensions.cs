using System.Linq;
using System.Reflection;


namespace Transacao.Infraestructure.Utils
{
    public static class SuperAppDomainExtensions
    {
        public static Assembly[] GetSuperLoadedAssemblies(this AppDomain domain)
        {
            var superAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName?.Contains("Transa") == true)
                .ToArray();

            return superAssemblies;
        }
    }
}