using BlazorServerCrudDotNet8.Components;
using BlazorServerCrudDotNet8.Data;
using BlazorServerCrudDotNet8.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=SherifAbdullah\\MSSQLSERVER01;Database=VideoGameDb;TrustServerCertificate=true;Trusted_Connection=true"));
builder.Services.AddScoped<IVideoGameService, VideoGameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
