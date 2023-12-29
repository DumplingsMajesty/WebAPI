var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions { SourceCodeLineCount = 20 });
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{

    //app.UseExceptionHandler("/api/Values");//当发生异常时，将会访问这里指定的API

    //app.UseExceptionHandler(  // 当发生异常时，会输出这里的内容
    //    options =>
    //    {
    //        options.Run(async context =>
    //        {
    //            context.Response.ContentType = "text/html";
    //            context.Response.StatusCode = 200;
    //            await context.Response.WriteAsync("error");
    //        });
    //    });

    app.UseExceptionHandler(new ExceptionHandlerOptions
    {
        AllowStatusCode404Response = true,
        ExceptionHandler = async context =>
        {
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("error");

        },
        ExceptionHandlingPath = "/api/Values"
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

