using Azure.Storage.Blobs;
using File.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(configs =>
{
    configs.Authority = builder.Configuration["IdentityServerURL"]; //Token dağıtmakla görevli api.Kritik! Bu kısmı appSettings.json da belirttik
    //Private key ile imzalanmış bir token geldiğinde public key ile doğrulaması yapılacak 
    configs.Audience = "fileapi_resource"; //IdentityServer'da belirttiğimiz isim.!
    configs.RequireHttpsMetadata = true; //Https kullandığımız için.
}); //Scheme name. Birden fazla token türü bekleniyor olabilir.Bu ayrımı yapmak için Scheme name kullanılır.

builder.Services.AddControllers(
    opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IImageService, ImageService>();
builder.Services.AddSingleton(new BlobServiceClient(builder.Configuration.GetValue<string>("AzureBlobStorageConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
