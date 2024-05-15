using Microsoft.EntityFrameworkCore;
using Asp.DALL.Context;
using Asp.DALL.Repositray;
using Asp.DALL.Entites;
using ProjectMohammadRepositry.Infra;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

Inject inject = new Inject();
inject.InjectClass(builder.Services);

//localaiztion
builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//end localaiztion

builder.Services.AddAutoMapper(typeof(Mapping));
//localaiztion
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
// end localaiztion

builder.Services.AddControllersWithViews()
    .AddViewLocalization
    (LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
//localaiztion
var cultures = new CultureInfo[]
           {
                new CultureInfo("en"),
                new CultureInfo("ar") { DateTimeFormat = { Calendar = new GregorianCalendar() }
                ,NumberFormat = new CultureInfo( "en-US", false ).NumberFormat }
           };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "ar" };
    options.SetDefaultCulture(supportedCultures[1])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
    options.SupportedCultures = cultures;
    options.SetDefaultCulture(supportedCultures[1]);
});
var app = builder.Build();
var supportedCultures = new[] { "en-US", "ar" };

// Culture from the HttpRequest
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
localizationOptions.SupportedCultures = cultures;
localizationOptions.SetDefaultCulture(supportedCultures[1]);
app.UseRequestLocalization(localizationOptions);
// end localaiztion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//localaiztion
app.UseSession();

//end localaiztion

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
