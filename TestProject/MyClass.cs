using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class MyClass
    {
        int i { get; set; }
        string str;
        private double a;
        private int GetInt()
        {
            return i;
        }
        public void SetDouble(double doub)
        {
            a = doub;
        }
        public static void Flex()
        {
            return;
        }
    }
}
