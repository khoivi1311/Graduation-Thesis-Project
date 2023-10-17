using Microsoft.AspNetCore.Mvc.Versioning;
using learn_programming_services.Extensions.DependencyInjection;
using learn_programming_services.Database;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection with Database
builder.Services.AddEntityFrameworkMySQL().AddDbContext<LearnProgrammingContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("myStringCon")));

// Versioning of Apis
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));

});

//Enable CORS for service
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});

builder.Services.AddMyRepositoryServicesGroup()
                .AddMyServiceServicesGroup()
                .AddMyUtilServicesGroup()
                .AddMyAuthenticationFunctionServicesGroup()
                .AddMyUserFunctionServicesGroup()
                .AddMyCourseFunctionServicesGroup()
                .AddMyContestFunctionServicesGroup()
                .AddMyPracticeFunctionServicesGroup()
                .AddMyDiscussionFunctionServicesGroup();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var config = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        //Tu cap Token
        ValidateIssuer = false,
        ValidateAudience = false,

        //Ky vao Token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(config.GetValue<string>("Token:secretKey"))),

        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddHttpClient("JobeServer", client =>
{
    client.BaseAddress = new Uri("http://209.97.164.53:4000/jobe/index.php/restapi/");
});

var app = builder.Build();

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
