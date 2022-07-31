using AppMvc.Net.ExtendMethods;
using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options => {
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddSingleton<ProductService, ProductService>();

builder.Services.AddSingleton<PlanetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.AddStatusCodePage();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "first",
//    pattern: "{url}/{id?}",
//    defaults: new
//    {
//        controller = "First",
//        action = "ViewProduct"
//    },
//    constraints: new
//    {
//        url = "xemsanpham",
//        id = new RangeRouteConstraint(2, 4)
//    }
//);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.Run();
