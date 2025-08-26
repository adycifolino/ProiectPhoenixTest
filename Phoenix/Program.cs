using Phoenix.DAL.Interfaces;
using Phoenix.DAL.Repositories;
using Phoenix.BLL.Interfaces;
using Phoenix.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Ia connection string
var connectionString = builder.Configuration.GetConnectionString("PhoenixDb");

// Configurează serviciile înainte să construiești aplicația
builder.Services.AddScoped<IPartenerRepository>(provider =>
    new PartenerRepository(connectionString));
builder.Services.AddScoped<IPartenerService, PartenerService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurează pipeline-ul HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Partener}/{action=Index}/{id?}");

app.Run();