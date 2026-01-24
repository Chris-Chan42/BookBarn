using BookBarn.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookBarnContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookBarnConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookBarnContext>();

    if (!db.Books.Any())
    {
        db.Books.AddRange(
            new Book { Title = "The Pragmatic Programmer", Author = "Hunt & Thomas", Price = 42.00m },
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Price = 38.50m },
            new Book { Title = "Design Patterns", Author = "Gamma et al.", Price = 55.00m }
        );

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
