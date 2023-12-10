using MedPro.EF;
/*using MedPro.Services;
*/
using MedPro.CORE.IRepositories;
using MedPro.EF.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MedPro.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();

app.UseCors(config =>
{
    config.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
