using XgHao.Demo.DependencyInjection.Base.DependencyInjection;

namespace XgHao.Demo.DependencyInjection.Service.Foo;

public class FooTimeService : IDiService
{
    private readonly FooService _fooService;

    public FooTimeService(FooService fooService)
    {
        _fooService = fooService;
    }

    /// <summary>
    /// 获取数据.
    /// </summary>
    /// <returns></returns>
    public List<string> GetDataList()
    {
        var dataList = _fooService.GetDataList();

        return dataList.Select(e => $"[{DateTime.Now}]: {e}").ToList();
    }
}