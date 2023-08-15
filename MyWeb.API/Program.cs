using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowSites",builder =>
    {
        builder.WithOrigins("https://localhost:44384").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    //opt.AddPolicy("AllowSites2", builder =>
    //{
    //    builder.WithOrigins("https://www.mysite.com").WithHeaders(HeaderNames.ContentType, "x-custom-header");
    //});
    //opt.AddPolicy("AllowSites3", builder =>
    //{
    //    builder.WithOrigins("https://*.example.com").SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader();
    //});
    opt.AddPolicy("AllowSites4", builder =>
    {
        builder.WithOrigins("https://localhost:44384").WithMethods("POST","GET").AllowAnyHeader();
        builder.AllowCredentials();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
