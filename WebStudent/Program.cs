using Microsoft.EntityFrameworkCore;
using WebStudent.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

// Add services to the container.
builder.Services.AddRazorPages();

// Register DbContext with SQL Server provider
builder.Services.AddDbContext<StudentsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
