using Microsoft.AspNetCore.Mvc;
using WebApi005.Attibutes;
using WebApi005.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.全局应用
//builder.Services.AddMvc(setupAction);

//void setupAction(MvcOptions options)
//{
//    options.Filters.Add<MyFilter>();
//}

// Add services to the container.指定位置应用
//builder.Services.AddMvc(options => { options.Filters.Add<MyFilter>(); });
builder.Services.AddScoped < MyActionFilterAttribute > ();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
