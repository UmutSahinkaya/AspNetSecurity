using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opts =>
{
    opts.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());//Bu filter eklendikten sonra art�k her "POST" methodunun �zerinde belirtmemize gerek kalmayacak!!!
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();//Strict-Transport-Security header(response)
}

app.UseHttpsRedirection();//e�er kullan�c� http iste�i atarsa kullan�c�y� https olan (ssl) sertifikal� sayfaya y�nlendir. 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
