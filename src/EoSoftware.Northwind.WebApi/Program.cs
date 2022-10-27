using MediatR;
using Microsoft.EntityFrameworkCore;
using Hellang.Middleware.ProblemDetails;
using Serilog;
using EoSoftware.Northwind.Application;
using EoSoftware.Northwind.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, services, configuration) => 
{   
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});

builder.Services.AddProblemDetails();

builder.Services.AddDbContext<NorthwindDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("NorthwindDbContext"));
});
builder.Services.AddScoped<INorthwindDbContext>(s => s.GetService<NorthwindDbContext>()!);

builder.Services.AddMediatR(typeof(GetRegionsListQuery).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseProblemDetails();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
}); 
//app.UseSerilogRequestLogging(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
