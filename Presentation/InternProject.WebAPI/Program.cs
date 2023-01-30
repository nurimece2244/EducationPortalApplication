
using InternProject.Domain.Entities;
using InternProject.Persistence;
using InternProject.Persistence.Context;
using InternProject.Persistence.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TokenOptions = InternProject.Persistence.Services.Token.TokenOptions;

var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = builder.Configuration;

var asd = configuration.GetSection("ConnectionStrings:DefaultConnection").Get<string>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc( option => option.EnableEndpointRouting = false);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);
 
});
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));
// contruc. içerisinde TokenOption gördüğü zaman Token değerlerini yazacak

builder.Services.AddPersistanceLayer();

var tokenoptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(
    options => 
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(jwtbeareroption =>
{
    jwtbeareroption.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenoptions.Issuer,
        ValidAudience = tokenoptions.Audience,
        IssuerSigningKey = SignHandler.GetSecurityKey(tokenoptions.SecurityKey)

    };
});
    
    
    builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Kafein Foramind Test API", Version = "v1" });
    options.DocInclusionPredicate((docName, description) => true);
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme()
        {
            In = ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage(); // sayfadaki hatayla ilgili açıklayıcı bilgi
app.UseStatusCodePages(); // content dönmeyen sayfalarda açıklama
app.UseStaticFiles();


app.UseHttpsRedirection();
app.UseAuthentication();


app.MapControllers();
app.UseAuthorization();

app.Run();