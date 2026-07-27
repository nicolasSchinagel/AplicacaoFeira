using AplicacaoFeira.Repository;
using AplicacaoFeira.Repository.Contract;
using Microsoft.AspNetCore.Localization;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<AplicacaoFeira.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<AplicacaoFeira.Libraries.Login.LoginCliente>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Definir um tempo para duração. 
    options.IdleTimeout = TimeSpan.FromSeconds(900);
    options.Cookie.HttpOnly = true;
    // Mostrar para o navegador que o cookie e essencial   
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseSession();

app.Run();


