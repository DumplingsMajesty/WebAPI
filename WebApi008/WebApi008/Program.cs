using WebApi008.Logs;
using NLog;
using NLog.Web;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var a1 = builder.Logging.Services.ToList();
    builder.Services.AddControllersWithViews();

    //builder.Logging.ClearProviders();
    //builder.Logging.AddDebug();
    //builder.Logging.AddConsole();
    //builder.Logging.AddEventLog();//Only Windows OS
    //builder.Logging.AddEventSourceLogger();
    //builder.Logging.AddSqlLog("���ݿ�����");

    // NLog: Setup NLog for Dependency injection
    //builder.Logging.ClearProviders();
    builder.Host.UseNLog();


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
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
