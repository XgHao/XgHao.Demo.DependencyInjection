using Microsoft.AspNetCore.Mvc;
using XgHao.Demo.DependencyInjection.Service.Foo;

namespace XgHao.Demo.DependencyInjection.WebAPI.Foo.Controllers
{
    public class FooController : Controller
    {
        private readonly FooService _fooService;
        private readonly FooTimeService _fooTimeService;

        public FooController(FooService fooService, FooTimeService fooTimeService)
        {
            _fooService = fooService;
            _fooTimeService = fooTimeService;
        }

        [HttpGet]
        [HttpPost]
        [Route("v1/Foo/GetDataList")]
        public List<string> GetDataList()
        {
            return _fooTimeService.GetDataList();
        }
    }
}
