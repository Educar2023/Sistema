using FacturacionElectronica.repository.implement;
using FacturacionElectronica.repository.interfaces;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacturacionElectronica
{
    public class Injector
    {
        private static Dictionary<Type, Type> mappings
            = new Dictionary<Type, Type>();

        public static T Get<T>()
        {
            var type = typeof(T);
            return (T)Get(type);
        }

        private static object Get(Type type)
        {
            var target = ResolveType(type);
            var constructor = target.GetConstructors()[0];
            var parameters = constructor.GetParameters();

            List<object> resolvedParameters = new List<object>();

            foreach (var item in parameters)
            {
                resolvedParameters.Add(Get(item.ParameterType));
            }

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private static Type ResolveType(Type type)
        {
            if (mappings.Keys.Contains(type))
            {
                return mappings[type];
            }

            return type;
        }

        public static void Map<T, V>() where V : T
        {
            mappings.Add(typeof(T), typeof(V));
        }

        public static void Clear()
        {
            mappings.Clear();
        }

        public static void init()
        {
            Map<IIFacVtaRepository, IFacVtaRepositoryImpl>();
            Map<IIFacVtaService, IFacVtaServiceImpl>();
            Map<ITFacVtaRepository, TFacVtaRepositoryImpl>();
            Map<ITFacVtaService, TFacVtaServiceImpl>();
            Map<IDirectorioRepository, DirectorioRepositoryImpl>();
            Map<IDirectorioService, DirectorioServiceImpl>();
            Map<ITickectSunatRepository, TickectSunatRepositoryImpl>();
            Map<ITicketSunatServices, TicketSunatServicesImpl>();
        }
    }
}
