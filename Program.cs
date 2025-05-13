using Licensing_Web.Data;
using Licensing_Web.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ImportDataService>();
builder.Services.AddScoped<ActionTypeService>();
builder.Services.AddScoped<BranchAddressService>();

builder.Services.AddSession();
builder.Services.AddRazorPages();

var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("localDb")
    : builder.Configuration.GetConnectionString("DockerDb");

// Register the DbContext with the selected connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();


app.UseSession();  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
