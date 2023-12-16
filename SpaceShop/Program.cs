using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using Shop.Data;
using SignalRChat.Hubs;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>()//only confirm email allowed (options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopContext>();

builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();

builder.Services.AddScoped<IFileServices, FilesServices>();// Mistakes: AggregateException: Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Shop.Core.ServiceInterface.ISpaceshipServices Lifetime
builder.Services.AddSignalR();


builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IAccuWeatherServices,AccuWeatherServices>();
builder.Services.AddScoped<IEmailService,EmailServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider=new PhysicalFileProvider
    ( Path.Combine(builder.Environment.ContentRootPath,"multipleFileUpload")),
    RequestPath="/multipleFileUpload"
});

app.UseRouting();
app.UseAuthentication(); ;
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
