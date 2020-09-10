using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
