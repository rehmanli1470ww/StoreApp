using ImageServiceApi.Services;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("https://*:10604");


builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit=int.MaxValue;
    o.MultipartBodyLengthLimit=int.MaxValue;
    o.MemoryBufferThreshold=int.MaxValue;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
