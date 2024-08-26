using MarcheEtDevient.Server.Data;
using MarcheEtDevient.Server.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalHost",
builder => {builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
});

// Add services to the container.
builder.Services.AddScoped<IAuthentificationRepository, AuthentificationRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configuration du lien de connection de la class apidbcontexte avec un connection string qui se situe dans setting.json
builder.Services.AddDbContext<ApiDBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DataBaseContexteClasse"));
});
var app = builder.Build();
app.UseCors("AllowLocalHost");
app.UseDefaultFiles();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
