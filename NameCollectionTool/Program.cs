using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using NameCollectionTool.Services;
using NameCollectionTool.Services.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddScoped<ICollectionsService, CollectionsService>();
builder.Services.AddScoped<IPersonNameService, PersonNameService>();
builder.Services.AddScoped<IPlaceNamesService, PlaceNamesService>();
builder.Services.AddScoped<ITitleNameService, TitleNameService>();
builder.Services.AddScoped<ISpellNameService, SpellNameService>();
builder.Services.AddScoped<IArtefactNameService, ArtefactNameService>();
builder.Services.AddScoped<IOtherNameService, OtherNameService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(
         opt =>
         {
             var supportCulteres = new List<CultureInfo>
             {
                new CultureInfo("en"),
                new CultureInfo("fr")
             };
             opt.DefaultRequestCulture = new RequestCulture("en");
             opt.SupportedCultures = supportCulteres;
             opt.SupportedUICultures = supportCulteres;
         });

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

app.UseRouting();

app.UseAuthorization();

var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
