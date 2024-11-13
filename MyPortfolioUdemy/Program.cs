var builder = WebApplication.CreateBuilder(args);

// Session ayarlar�
builder.Services.AddDistributedMemoryCache(); // Bellek tabanl� cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum s�resi
});

// DbContext ve Controller servisleri
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata y�netimi ve geli�tirme ortam� kontrol�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Session kullan�m�n� etkinle�tir
app.UseSession();

// Routing ve authorization
app.UseRouting();
app.UseAuthorization();

// Controller rotas� tan�mlamas�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
