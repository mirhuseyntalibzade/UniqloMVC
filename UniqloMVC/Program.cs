using Microsoft.EntityFrameworkCore;
using UniqloBL.Services.Abstractions;
using UniqloBL.Services.Concretes;
using UniqloDAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddDbContext<UniqloDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});

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