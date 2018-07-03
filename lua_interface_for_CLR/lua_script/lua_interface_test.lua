require "luanet"
luanet.load_assembly('lua_interface_for_CLR'); --引入命名空间（程序集）
Testluaandc1 = luanet.import_type("lua_interface_for_CLR.TestLuaAndC")--引入程序集下的类
Testluaandc2 = luanet.import_type("lua_interface_for_CLR.Program")

--调用C#的重载函数
obj1 = Testluaandc1(2,3)
obj2 = Testluaandc1("shaco")
obj3 = Testluaandc1(3)

--调用C#的类
Testluaandc = Testluaandc2()
--访问类的字段
print(Testluaandc.name)
--访问类的方法
print(Testluaandc:Test_Method())

--手动匹配构造函数
Testluaandc_cons3 = luanet.get_constructor_bysig(Testluaandc1, 'System.Int32')
obj3 = Testluaandc_cons3(3)