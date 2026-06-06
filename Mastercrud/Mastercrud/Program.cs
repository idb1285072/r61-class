using Microsoft.EntityFrameworkCore;
using static Mastercrud.Models.DbModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HospitalDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
