using Microsoft.EntityFrameworkCore;
using UniqloBL.Services.Abstractions;
using UniqloBL.Services.Concretes;
using UniqloDAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UniqloDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<ISliderItemService, SliderItemsService>();


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();