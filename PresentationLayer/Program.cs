using DataAccessLayer.DI;
using BusinessLayer.DI;
using DataAccessLayer.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddData();
builder.Services.AddBusinessLayer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();