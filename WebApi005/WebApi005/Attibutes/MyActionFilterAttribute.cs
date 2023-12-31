﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;

namespace WebApi005.Attibutes
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IConfiguration configuration;

        public MyActionFilterAttribute(IConfiguration configuration) {
            this.configuration = configuration;

        }


        /// <summary>
        /// 尽量使用异步方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var aa = configuration["Logging:LogLevel:Default"];
            return base.OnActionExecutionAsync(context, next);
        }

        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            return base.OnResultExecutionAsync(context, next);
        }

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //}

        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    base.OnResultExecuted(context);
        //}

        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    base.OnResultExecuting(context);
        //}
    }
}
