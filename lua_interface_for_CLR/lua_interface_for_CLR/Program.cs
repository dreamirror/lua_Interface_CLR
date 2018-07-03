using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;
namespace lua_interface_for_CLR
{
    class Program
    {
        class TestReg {
            private int value = 0;
            public void TestRegFun(int num) {
                Console.WriteLine("testreg.testregfun is running value=={0}",value = num);

            }
            public static void TestStatic() {
                Console.WriteLine("test.teststatic is running");
            }
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

            // Lua的索引操作[]可以创建、访问、修改global域，括号里面是变量名
            // 创建global域num和str
            lua["num"] = 2;
            lua["str"] = "a string";

            // 创建空table
            lua.NewTable("tab");

            // 执行lua脚本，着两个方法都会返回object[]记录脚本的执行结果
            lua.DoString("num = 100; print(\"i am a lua string\")");
            lua.DoFile("../../../lua_script/lua_interface_test.lua");
            object[] retVals = lua.DoString("return num,str");

            // 访问global域num和str
            lua_alpha["num"] = 222;
            double num = (double)lua_alpha["num"];
            string str = (string)lua["str"];

            Console.WriteLine("num = {0}", num);
            //Console.WriteLine("str = {0}", str);
            //Console.WriteLine("width = {0}", lua["width"]);
            //Console.WriteLine("height = {0}", lua["height"]);
            char ch;
            ch = (char)Console.Read(); // get a char
        }
    }
}
