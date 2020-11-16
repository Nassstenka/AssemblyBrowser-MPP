using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowsing
{
    public class TypeInformation
    {
       public Type TypeName { get; private set; }
       public List<MethodInfo> MethodList { get; private set; } = new List<MethodInfo>();

       public List<PropertyInfo> PropertyList { get; private set; } = new List<PropertyInfo>();

       public List<FieldInfo> FieldList { get; private set; } = new List<FieldInfo>();

       public TypeInformation(Type type)
       {
           TypeName = type;
       }
    }
    public class NamespaceInformation
    {
        public string NamespaceName { get; private set; }
        public List<TypeInformation> TypeList { get; private set; } = new List<TypeInformation>();
        public NamespaceInformation(string name)
        {
            NamespaceName = name;
        }
    }
    public class AssemblyInformation
    {
        public string AssemblyName { get; private set; }
        public Dictionary<string, NamespaceInformation> NamespaceList { get; private set; } = new Dictionary<string, NamespaceInformation>();
        public AssemblyInformation(string name)
        {
            AssemblyName = name;
        }
    }
}
