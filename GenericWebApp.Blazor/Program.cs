using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using GenericWebApp.BLL.Music;
using GenericWebApp.Model.Music;
using GenericWebApp.Model.Management;
using GenericWebApp.BLL.Management;
using GenericWebApp.Model.Template;
using GenericWebApp.BLL.Template;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AlbumContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("GenericWebApp.Model");
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }),
        ServiceLifetime.Scoped);

builder.Services.AddDbContext<ManagementContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("GenericWebApp.Model");
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }),
        ServiceLifetime.Scoped);

builder.Services.AddDbContext<TemplateContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("GenericWebApp.Model");
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }),
        ServiceLifetime.Scoped);

builder.Services.AddScoped<Service>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<DashboardAlbumService>();
builder.Services.AddScoped<DashboardManagementService>();
builder.Services.AddScoped<MedicalCMS1500Service>();
builder.Services.AddScoped<TemplateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Apply pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AlbumContext>();
    dbContext.Database.Migrate();
}

// Apply pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ManagementContext>();
    dbContext.Database.Migrate();
}

// Apply pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TemplateContext>();
    dbContext.Database.Migrate();
}

app.Run();
