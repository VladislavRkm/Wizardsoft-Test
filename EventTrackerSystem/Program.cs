using EventTrackerApplication.Services;
using EventTrackerCore.Abstractions;
using EventTrackerDAL;
using EventTrackerDAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });
builder.Services.AddDbContext<EventTrackerContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("EventTrackerContext"));
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddControllers().AddJsonOptions(options => {
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; options.JsonSerializerOptions.MaxDepth = 64;
});


var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
