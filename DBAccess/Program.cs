using DBAccess.AppContext;
using DBAccess.IRepos;
using DBAccess.IRepositoryImplementations;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen((o) =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});


builder.Services.AddAuthentication(opt =>
{    
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime=false,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
var conn = builder.Configuration["Conn"];


#region dependancy added
builder.Services.AddScoped<IRegisterRepo, RegisterationImp>()
//.AddScoped<IContraction, ContractionImp>()
.AddScoped<IQualification, QualificationImp>()
.AddScoped<IAdminTemplates, AdminTemplateImp>()
.AddScoped<IFaculty, FacultyImp>()
.AddScoped<IGallary, GallaryImp>()
.AddScoped<ICompany, CompanyImp>();
#endregion


builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<SSOContext>((o) => o.UseSqlServer(conn));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores((o) => {

//});

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors((option) => { option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });

app.Run();
