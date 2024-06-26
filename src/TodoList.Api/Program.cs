using Elastic.Apm.NetCoreAll;
using Serilog;
using TodoList.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.ReadFrom.Configuration(builder.Configuration);
});

Log.Information("Starting API");

// Add services to the container.
builder.AddDatabase()
       .AddDependencies()
       .AddMessageBroken();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseGlobalExceptionHandler();

app.UseCors();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
