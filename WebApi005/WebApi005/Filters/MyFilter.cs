using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi005.Filters
{
    public class MyFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 对参数的验证
            // 记录访问日志

            Console.WriteLine("OnActionExecutionAsync Before");
            await next();

            Console.WriteLine("OnActionExecutionAsync After");
            // 数据格式化

        }
    }
}
