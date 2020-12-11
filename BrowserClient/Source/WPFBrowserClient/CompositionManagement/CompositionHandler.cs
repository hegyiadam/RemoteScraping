using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace WPFBrowserClient.CompositionManagement
{
    public static class CompositionHandler
    {
        public static void Compose(Type interfaceType, object composablePart)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(interfaceType.Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(composablePart);
        }
    }
}