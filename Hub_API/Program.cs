using Application;

using Application.Interface.SecurityModule.Master;
using Application.Interface.SecurityModule.Transaction;

using Application.Repository.SecurityModule.Master;
using Application.Repository.SecurityModule.Transaction;
using Domain;
using Hub_API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddControllers()
//        .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling =
//    ReferenceLoopHandling.Ignore
//);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddTenancy(builder.Configuration);
//builder.Services.AddDbContext<HUB_Context>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<BaseRepository<City>, CityReporitory>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuth, AuthRepository>();
builder.Services.AddScoped<IGroupPermission, GroupPermissionRepository>();
builder.Services.AddScoped<IPrgPer, PrgPerRepository>();
builder.Services.AddScoped<ICreateMasterFront, CreateMasterForm>();

//builder.Services.AddMvc()
//        .AddJsonOptions(
//            options => options.JsonSerializerOptions.IncludeFields  = false
//        );
builder.Services.AddCors(option => option.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}
                ));
var key = System.Text.Encoding.UTF8.GetBytes("AFego$#*&!@UYREpopop*&!Bts11111GSWInvoice@2021whm#@");
var signingKey = new SymmetricSecurityKey(key);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddCookie()
.AddJwtBearer(x =>
{
x.RequireHttpsMetadata = false;
x.SaveToken = true;

x.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = false,
    IssuerSigningKey = signingKey,
    ValidateAudience = false,
    ValidateIssuer = false,
    ClockSkew = TimeSpan.Zero
   
};
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    GlobalVars.ClientUrl = "http://localhost:4200";
}
else
{
    GlobalVars.ClientUrl = "http://localhost:4200";

}
app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
