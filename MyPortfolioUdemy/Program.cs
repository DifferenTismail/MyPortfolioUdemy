var builder = WebApplication.CreateBuilder(args);

// Session ayarlarý
builder.Services.AddDistributedMemoryCache(); // Bellek tabanlý cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
});

// DbContext ve Controller servisleri
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata yönetimi ve geliþtirme ortamý kontrolü
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Session kullanýmýný etkinleþtir
app.UseSession();

// Routing ve authorization
app.UseRouting();
app.UseAuthorization();

// Controller rotasý tanýmlamasý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
