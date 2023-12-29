var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/weatherforecast", () =>
{
    return "weatherforecast";
});

app.MapWhen(context =>
{
    return context.Request.Query.ContainsKey("abc");
}, app1 =>
{
    app1.Run(async content =>
    {
        await content.Response.WriteAsync("Default");
    });
}

);

app.MapWhen(context => context.Request.Method.ToUpper() == "POST",
    app1 =>
    {
        app1.MapWhen(context => context.Request.Query.ContainsKey("a1"),
            app2 =>
            {
                app2.Run(async content =>
                {
                    await content.Response.WriteAsync("a1");
                });
            });
        app1.MapWhen(context => context.Request.Query.ContainsKey("a2"),
            app2 =>
            {
                app2.Run(async content =>
                {
                    await content.Response.WriteAsync("a2");
                });
            });
    }


);

app.Run();

