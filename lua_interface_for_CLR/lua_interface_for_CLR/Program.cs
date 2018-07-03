using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;
namespace lua_interface_for_CLR
{
    class TestReg
    {
        private int value = 0;
        public void TestRegFun(int num)
        {
            Console.WriteLine("testreg.testregfun is running value=={0}", value = num);

        }
        public static void TestStatic()
        {
            Console.WriteLine("test.teststatic is running");
        }
    }

    class TestLuaAndC
    {
        public TestLuaAndC(string str)
        {
            Console.WriteLine("called TestLuaAndC(string str) str = {0}", str);
        }

        public TestLuaAndC(int num)
        {
            Console.WriteLine("called TestLuaAndC(int num) num = {0}", num);
        }

        public TestLuaAndC(int num1, int num2)
        {
            Console.WriteLine("called TestLuaAndC(int num1, int num2) num1 = {0}, num2 = {1}", num1, num2);
        }
    }

    class Program
    {
        public string name = "C#name";

        public void Test_Method()
        {
            Console.WriteLine("called C# method.");
        }

        static void Main(string[] args)
        {
            // 新建一个Lua解释器，每一个Lua实例都相互独立
            Lua lua = new Lua();
            Lua lua_alpha = new Lua();

            TestReg obj = new TestReg();
            lua.RegisterFunction("LuaTestRegFun", obj, obj.GetType().GetMethod("TestRegFun"));

            //注册CLR静态方法到Lua中
            // 也可用 typeof(TestReg).GetMethod("TestRegFun")
            lua.RegisterFunction("LuaTestStatic", null, typeof(TestReg).GetMethod("TestStatic"));

            // 执行lua脚本，着两个方法都会返回object[]记录脚本的执行结果
            lua.DoFile("../../../lua_script/lua_interface_test.lua");
            // 访问global域num和str
            char ch;
            ch = (char)Console.Read(); // get a char
        }
    }
}
