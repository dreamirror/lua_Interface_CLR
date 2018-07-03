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
        static void Main(string[] args)
        {
            // 新建一个Lua解释器，每一个Lua实例都相互独立
            Lua lua = new Lua();

            // Lua的索引操作[]可以创建、访问、修改global域，括号里面是变量名
            // 创建global域num和str
            lua["num"] = 2;
            lua["str"] = "a string";

            // 创建空table
            lua.NewTable("tab");

            // 执行lua脚本，着两个方法都会返回object[]记录脚本的执行结果
            lua.DoString("num = 100; print(\"i am a lua string\")");
            lua.DoFile("F:\\unity\\lua_interface_for_CLR\\lua_interface_for_CLR\\lua_script\\lua_interface_test.lua");
            object[] retVals = lua.DoString("return num,str");

            // 访问global域num和str
            double num = (double)lua["num"];
            string str = (string)lua["str"];

           // Console.WriteLine("num = {0}", num);
            //Console.WriteLine("str = {0}", str);
            //Console.WriteLine("width = {0}", lua["width"]);
            //Console.WriteLine("height = {0}", lua["height"]);
            char ch;
            ch = (char)Console.Read(); // get a char
        }
    }
}
