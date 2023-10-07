using Ecommerce.BL;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerecContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB")));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddIdentity<Customer, IdentityRole>()
    .AddEntityFrameworkStores<EcommerecContext>();
builder.Services.AddAuthentication(p =>
{
    p.DefaultAuthenticateScheme = "smsm";
    p.DefaultChallengeScheme = "smsm";
}).AddJwtBearer("smsm", options =>
{
    var key = builder.Configuration.GetValue<string>("secretKey");
    var keyInBytes = Encoding.ASCII.GetBytes(key);
    var keyObject = new SymmetricSecurityKey(keyInBytes);
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        IssuerSigningKey = keyObject,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
