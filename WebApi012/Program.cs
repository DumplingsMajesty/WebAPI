using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/weatherforecast", () =>
{
    Console.WriteLine("MapGet");
    return "Hello World";
    Console.WriteLine("use 1 MapGet");
});

app.Use(async (context, next) =>
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    Console.WriteLine("use 1 start");
    await next();

    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedMilliseconds);
})
.Use(async (context, next) =>
{
    Console.WriteLine("use 2 start");
    await next();
    Console.WriteLine("use 2 end");
})
.Use(async (context, next) =>
 {
     Console.WriteLine("use 3 start");
     await next();
     Console.WriteLine("use 3 end");
 });
;

app.Run();

