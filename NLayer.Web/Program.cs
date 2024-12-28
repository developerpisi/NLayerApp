using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using NLayer.Repository;
using NLayer.Service.Mapping;
using NLayer.Web;
using NLayer.Web.Modules;
using NLayer.Web.Services;
using Microsoft.EntityFrameworkCore;
using NLayer.Service.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>()); ;
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 3, 0)),
        option =>
        {
            option.MigrationsAssembly("NLayer.API");
        }
    )
);

builder.Services.AddHttpClient<ProductApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});
builder.Services.AddHttpClient<CategoryApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});


builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();