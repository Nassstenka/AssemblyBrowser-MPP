using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestClass
    {
        WpfApp.Model model;
        AssemblyBrowsing.AssemblyInformation assembly;
        [TestInitialize]
        public void TestInit()
        {
            model = new WpfApp.Model();
            assembly = model.LoadAssembly("E:\\BSUIR\\SPP\\Lab3\\TestProject\\bin\\Debug\\TestProject.exe");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsTrue(assembly.NamespaceList.ContainsKey("TestProject"));
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList.Count, 5);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[0].FieldList.Count, 2);  //!
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[0].PropertyList.Count, 1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[1].FieldList.Count, 2);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.IsTrue(assembly.NamespaceList["TestProject"].TypeList[2].MethodList[0].IsPublic);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.IsNotNull(assembly.NamespaceList);
            Assert.IsNotNull(assembly.NamespaceList["TestProject"].TypeList);
            Assert.AreEqual(assembly.NamespaceList["TestProject"].TypeList[3].PropertyList[0].PropertyType, typeof(int));
        }
    }
}
