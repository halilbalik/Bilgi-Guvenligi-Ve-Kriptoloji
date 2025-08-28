var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<Bilgi_Güvenliği_ve_Kriptoloji.Services.IAESService, Bilgi_Güvenliği_ve_Kriptoloji.Services.AESService>();
builder.Services.AddScoped<Bilgi_Güvenliği_ve_Kriptoloji.Services.IRSAService, Bilgi_Güvenliği_ve_Kriptoloji.Services.RSAService>();
builder.Services.AddScoped<Bilgi_Güvenliği_ve_Kriptoloji.Services.ISHAService, Bilgi_Güvenliği_ve_Kriptoloji.Services.SHAService>();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
