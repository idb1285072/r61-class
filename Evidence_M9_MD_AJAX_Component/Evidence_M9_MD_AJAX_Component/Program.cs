using Evidence_M9_MD_AJAX_Component.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddDbContext<DbEv7Context>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");
//app.MapGet("/", () => "Hello World!");

app.Run();
