using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Context;
using TemplateCRUDNet7.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBranchOfficeRepository, BranchOfficeRepository>();

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
var url_front = builder.Configuration.GetValue<string>("frontend_web_url");


// Add context sql lite
//builder.Services.AddDbContext<TemplateContext>(db =>
//{
//    db.UseSqlite(connectionString);
//});


// Add context sql server
builder.Services.AddDbContext<TemplateContext>(db =>
{
    db.UseSqlServer(connectionString);
});


var app = builder.Build();

// initialize the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TemplateContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// cors de la app
app.UseCors(x => x.WithOrigins(url_front)
.AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
