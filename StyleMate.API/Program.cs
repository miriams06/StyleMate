using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using StyleMateAPI.Data;
using StyleMateAPI.Repositories;
using StyleMateAPI.Services;
=======
using StyleMate1._1.Data;
using StyleMate1._1.Repositories;
using StyleMate1._1.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.Google;


>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84

var builder = WebApplication.CreateBuilder(args);
// Lê connection strings das variáveis de ambiente
var sqlConnection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION");
var blobConnection = Environment.GetEnvironmentVariable("AZURE_BLOB_CONNECTION");

builder.Configuration["ConnectionStrings:DefaultConnection"] = sqlConnection;
builder.Configuration["AzureBlobStorage:ConnectionString"] = blobConnection;

// Serviços base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de dados (Azure SQL)
builder.Services.AddDbContext<StyleMateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD
builder.Services.AddSingleton<AzureBlobService>();
=======
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
})
.AddCookie("Cookies")
.AddGoogle(options =>
{
    options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
    options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");
    options.CallbackPath = "/google-callback";
})
.AddMicrosoftAccount(options =>
{
    options.ClientId = Environment.GetEnvironmentVariable("ENTRA_CLIENT_ID");
    options.ClientSecret = Environment.GetEnvironmentVariable("ENTRA_CLIENT_SECRET");

    options.CallbackPath = "/signin-microsoft";

    // ADICIONAR ISTO
    options.Scope.Add("email");
    options.Scope.Add("openid");
    options.Scope.Add("profile");

    options.SaveTokens = true;
});



// Ler variáveis de ambiente para DEBUG
Console.WriteLine("===== VARIÁVEIS DE AMBIENTE =====");
Console.WriteLine("AZURE_SQL_CONNECTION: " + Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTION"));
Console.WriteLine("AZURE_BLOB_CONNECTION: " + Environment.GetEnvironmentVariable("AZURE_BLOB_CONNECTION"));
Console.WriteLine("ENTRA_CLIENT_ID: " + Environment.GetEnvironmentVariable("ENTRA_CLIENT_ID"));
Console.WriteLine("ENTRA_CLIENT_SECRET: " + Environment.GetEnvironmentVariable("ENTRA_CLIENT_SECRET"));
Console.WriteLine("ENTRA_TENANT_ID: " + Environment.GetEnvironmentVariable("ENTRA_TENANT_ID"));
Console.WriteLine("GOOGLE_CLIENT_ID: " + Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID"));
Console.WriteLine("GOOGLE_CLIENT_SECRET: " + Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET"));
Console.WriteLine("JWT_ISSUER: " + Environment.GetEnvironmentVariable("JWT_ISSUER"));
Console.WriteLine("JWT_AUDIENCE: " + Environment.GetEnvironmentVariable("JWT_AUDIENCE"));
Console.WriteLine("JWT_KEY: " + Environment.GetEnvironmentVariable("JWT_KEY"));
Console.WriteLine("=================================");


>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84


// Injeção de dependências
builder.Services.AddScoped<UtilizadorRepository>();
builder.Services.AddScoped<UtilizadorService>();
builder.Services.AddScoped<RoupaRepository>();
builder.Services.AddScoped<RoupaService>();
builder.Services.AddScoped<ConjuntoRepository>();
builder.Services.AddScoped<ConjuntoService>();
builder.Services.AddScoped<EventoRepository>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<MalaRepository>();
builder.Services.AddScoped<MalaService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
<<<<<<< HEAD
=======
app.UseAuthentication();
app.UseAuthorization();
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84

app.UseHttpsRedirection();
app.MapControllers();
app.Run();