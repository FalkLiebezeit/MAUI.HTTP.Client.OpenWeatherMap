using Autofac;

namespace MAUI.HTTP.Client.OpenWeatherMap
{

    public class Resolver
    {
        private static Autofac.IContainer container;

        public static void Initialize(Autofac.IContainer container)
        {
            Resolver.container = container;
        }


        /*
        public static T Resolve<T>()
        {
            return (T)container;
        }
        */

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        
    }
}
