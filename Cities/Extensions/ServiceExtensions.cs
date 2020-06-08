using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;

namespace Cities.Extensions
{
    /// <summary>
    /// Configurations related to Entity framework, Authentication and ASP.NET Core
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Cross Origin Resource Shared configuration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        /// <summary>
        /// IIS Integration configuration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// A wrapper for the repository pattern
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /// <summary>
        /// The repositories DI configuration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
        }

        /// <summary>
        /// Added the DB context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            //External DB (SQL Server)
            var connectionString = config["connectionString:MyConnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Authentication configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var citizenRepository = context.HttpContext.RequestServices.GetRequiredService<ICitizenRepository>();
                            var citizenId = int.Parse(context.Principal.Identity.Name ?? string.Empty);
                            var citizen = citizenRepository.GetByIdAsync(citizenId);
                            if (citizen == null)
                            {
                                // return unauthorized if citizen no longer exists
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        /// <summary>
        /// App.Settings configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(options => config.GetSection("MySettings").Bind(options));
        }
    }
}
