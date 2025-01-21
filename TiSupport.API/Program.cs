using Keycloak.AuthServices.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TiSupport.Core.Services;
using TiSupport.Core.Services.IService;
using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository;
using TiSupport.DataAccess.Repository.IRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// TODO: Fix/Test this for VUE
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:5174")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:8080/realms/tisupportkc";
        options.Audience = "vue"; // Zorg dat dit overeenkomt met je Keycloak-client
        options.RequireHttpsMetadata = false; // Alleen voor lokale ontwikkeling

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "http://localhost:8080/realms/tisupportkc", // Controleer tegen de issuer in het token
            ValidateAudience = true,
            ValidAudiences = new[] { "vue", "account" }, // Sta beide audiences toe
            ValidateLifetime = true, // Controleer of het token niet is verlopen
            ValidateIssuerSigningKey = true // Valideer de handtekening
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireGeneralRole", policy =>
        policy.RequireAssertion(context =>
            context.User.Claims.Any(c =>
                c.Type == "resource_access" &&
                c.Value.Contains("general"))))
    .AddPolicy("RequireAdminRole", policy =>
        policy.RequireAssertion(context =>
            context.User.Claims.Any(c =>
                c.Type == "resource_access" &&
                c.Value.Contains("admin"))))
    .AddPolicy("RequireRole", policy =>
        policy.RequireAssertion(context =>
            context.User.Claims.Any(c =>
                c.Type == "resource_access" &&
                (c.Value.Contains("admin") || c.Value.Contains("general")))));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketAttachmentService, TicketAttachmentService>();
builder.Services.AddScoped<ITicketCommentService, TicketCommentService>();

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

app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();