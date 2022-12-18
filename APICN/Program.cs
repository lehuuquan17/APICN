
using API_HTGT.Context;
using API_HTGT.Models;
using APICN.Helper;
using APICN.Hubs;
using FluentAssertions.Common;
using JwtWebApiTutorial.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

using static APICN.Models.Dvhcvn;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration(options =>
{
        options.AddJsonFile(@$"{AppDomain.CurrentDomain.BaseDirectory}\dvhcvn.json", optional: true, reloadOnChange: true);

});
// Add services to the container.

builder.Services.AddControllers();
//Adding MVC

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<MyDBcontext>(options => options.UseInMemoryDatabase("XEsDb"));
builder.Services.AddDbContext<MyDBcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("APICNApiConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
///AddScoped khoi tao moi lan request
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.Configure<List<Datum>>(builder.Configuration.GetSection("DataDvHcvn"));

builder.Services.AddSignalR();
///AddSingleton khởi tạo duy nhất 1 lần
//builder.Services.AddSingleton<IUserService, UserService>();
///AddSingleton khởi tạo mỗi lần gọi đến nó
//builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.Http,
                            Scheme = "Bearer",
                            BearerFormat = "JWT"


                        },
                        Array.Empty<string>()
                    }
                });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
    options.DocInclusionPredicate((name, api) => true);
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            //tự cấp token
            ValidateIssuer = false,
            ValidateAudience = false,

            //ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APICN", Version = "v1" });
});
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
})
.UseSwagger(options =>
{
    //options.SerializeAsV2 = true;
})
.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-1);
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API")  ;
    c.RoutePrefix = "swagger";
    c.DocumentTitle = "API";
})
.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
.UseHttpsRedirection()
.UseStaticFiles()
.UseRouting()
;

//app.UseCors("NgOrigins");

app.MapHub<SignalHub>("/signalhub");

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Auth}/{action=Login}/{id?}");
});
app.InitData();
app.Run();
