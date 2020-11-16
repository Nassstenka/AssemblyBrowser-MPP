using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowsing
{
    public class AssemblyBrowser
    {
        public AssemblyInformation BrowseAssembly(Assembly assembly)
        {
            Type[] types;
            string assemblyName = assembly.FullName;
            AssemblyInformation assemblyInfo = new AssemblyInformation(assemblyName);

            types = assembly.GetTypes();
            foreach (Type type in types)
            {
                NamespaceInformation namespaceInfo = new NamespaceInformation(type.Namespace);
                string namespaceName = namespaceInfo.NamespaceName;
                if (!assemblyInfo.NamespaceList.ContainsKey(namespaceName))
                {
                    assemblyInfo.NamespaceList.Add(namespaceName, namespaceInfo);
                }
                TypeInformation typeInfo = new TypeInformation(type);
                FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fields != null)
                {
                    foreach(FieldInfo field in fields)
                    {
                        typeInfo.FieldList.Add(field);
                    }
                }
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (properties != null)
                {
                    foreach (PropertyInfo property in properties)
                    {
                        typeInfo.PropertyList.Add(property);
                    }
                }
                MethodInfo[] methods = type.GetMethods();
                if (methods != null)
                {
                    foreach (MethodInfo method in methods)
                    {
                        typeInfo.MethodList.Add(method);
                    }
                }
                assemblyInfo.NamespaceList[namespaceName].TypeList.Add(typeInfo);
            }
            return assemblyInfo;
        }
    }
}
