using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ClassB : IClassB
    {
        string str;
        public List<int> list;
        public string JustString()
        {
            return "aaa";
        }
        public void SetString(string param)
        {
            str = param;
        }
    }
}
