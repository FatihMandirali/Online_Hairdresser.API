using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Core.Mapping;
using Online_Hairdresser.Core.Services;
using Online_Hairdresser.Core.Services;
using Online_Hairdresser.Data;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.Options;
using StackExchange.Redis;
using System.Globalization;
using System.Text;
using MongoDB.Driver;
using Online_Hairdresser.API.Filter;
using Online_Hairdresser.API.Middleware;
using Online_Hairdresser.Models.Exceptions;

namespace Online_Hairdresser.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ServiceCollectionExtension(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region RedisCache

            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration =
                    configuration
                        .GetConnectionString("Redis"); //localhost:6379,password=eYVX7EwVmmxKPCDmwMtyKVge8oLd2t81
            });
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

            #endregion

            #region AppSettingsOptions

            var cacheSettings = new CacheSettings();
            configuration.Bind(nameof(CacheSettings), cacheSettings);
            services.AddSingleton(cacheSettings);
            services.AddOptions<AppSettings>().BindConfiguration(nameof(AppSettings));
            services.Configure<MongoDBSettings>(
                configuration.GetSection("MongoDBSettings")
            );
            #endregion

            #region MemoryCache

            services.AddMemoryCache();

            #endregion

            #region Default

            services.AddControllers(options =>
                {
                    options.Filters.Add(new HttpResponseExceptionFilter());
                    options.Filters.Add(typeof(ValidateModelStateAttribute));
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
            services.AddEndpointsApiExplorer();
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            #endregion

            #region FluentValidation

            services.AddFluentValidation(conf => { conf.RegisterValidatorsFromAssembly(typeof(ErrorException).Assembly); });

            #endregion

            #region Multi-Language

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("tr")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "tr", uiCulture: "tr");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[]
                        { new RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };
                });

            //services.Configure<RouteOptions>(options =>
           // {
           //     options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
           // });

            #endregion

            #region Cors

            services.AddCors(p =>
                p.AddPolicy("corsapp", builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

            #endregion

            #region PostgreSql

            services.AddDbContext<OnlineHairdresserDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("SqlConnection"), npgOptions =>
                    npgOptions.MigrationsAssembly("Online_Hairdresser.Data")
            ));

            #endregion

            #region AutoMapper

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new OnlineHairdresserMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Swagger

            services.AddSwaggerGen();
            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JSON Web Token based security",
            };

            var securityReq = new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            };

            var contact = new OpenApiContact()
            {
                Name = "Online Hairdresser",
                Email = "fatih.mandirali@hotmail.com",
                Url = new Uri("http://www.mohamadlawand.com")
            };

            var license = new OpenApiLicense()
            {
                Name = "Free License",
                Url = new Uri("http://www.mohamadlawand.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Online Hairdresser - JWT Authentication with Swagger",
                Description = "Online Hairdresser - JWT Authentication with Swagger",
                TermsOfService = new Uri("http://www.example.com"),
                Contact = contact,
                License = license
            };

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", info);
                o.AddSecurityDefinition("Bearer", securityScheme);
                o.AddSecurityRequirement(securityReq);
            });

            #endregion

            #region Services

            services.AddScoped<IOnBoardingService, OnBoardingService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IPublicService, PublicService>();
            services.AddSingleton<IMongoClient>(s => 
            new MongoClient(configuration.GetValue<string>("MongoDBSettings:ConnectionString")));
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IRefreshTokenPostgreService, RefreshTokenPostgreService>();
            services.AddScoped<ICityCountyService, CityCountyService>();
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IUserFavoriteVenueService, UserFavoriteVenueService>();
            services.AddScoped<IVenueServicesService, VenueServicesService>();

            #endregion

            #region ExceptionService

            services.AddScoped<ExceptionCatcherMiddleware>();

            #endregion

            #region Authentication

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true, //expariotion for isrequired
                    ValidateIssuerSigningKey = true, //expariotion for isrequired
                    RequireExpirationTime = true, //expariotion for isrequired
                    ClockSkew = TimeSpan.Zero //expariotion for isrequired
                };
            });

            services.AddAuthorization();

            #endregion

            return services;
        }
    }
}