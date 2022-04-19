using OMS.Data.Access.Main;
using OMS.Data.Access.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Data.Access.DAL
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMap> GetMainMappings()
        {
            var assemblyTypes = typeof(CategoryMap).GetTypeInfo().Assembly.DefinedTypes;
            var mappings = assemblyTypes
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(CategoryMap).Namespace))
                .Where(t => typeof(IMap).GetTypeInfo().IsAssignableFrom(t));
            mappings = mappings.Where(x => !x.IsAbstract);
            return mappings.Select(m => (IMap)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}
