using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Person.Database;
using Person.Models.Persons;
using Person.PersonsService;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string dbPath = Path.Join(path, "PersonDb", "Person.db");

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<PersonService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
