using XgHao.Demo.DependencyInjection.Base.DependencyInjection;

namespace XgHao.Demo.DependencyInjection.Service.Foo;

public class FooService : IDiService
{
    /// <summary>
    /// 获取数据列表.
    /// </summary>
    /// <returns></returns>
    public List<string> GetDataList()
    {
        return new List<string>
        {
            "Foo1",
            "Foo2",
        };
    }
}