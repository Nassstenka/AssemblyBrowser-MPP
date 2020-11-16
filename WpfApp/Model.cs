using System.Reflection;
using AssemblyBrowsing;

namespace WpfApp
{
    public class Model
    {
        public AssemblyInformation LoadAssembly(string path)
        {
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
            Assembly assembly = Assembly.LoadFrom(path);
            return assemblyBrowser.BrowseAssembly(assembly);
        }
    }
}
