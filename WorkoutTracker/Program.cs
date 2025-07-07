
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorkoutTracker.Core.BaseSpec;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.CreateToken;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Repository;
using WorkoutTracker.Repository.Repositories;

namespace WorkoutTracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();








            //Database
            builder.Services.AddDbContext<WorkoutTrackerDbContext>(options
                 => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                 );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<WorkoutTrackerDbContext>()
                        .AddDefaultTokenProviders();



            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            //builder.Services.AddScoped(typeof(ISpec<>) , typeof(Spec<>) );   Don't Need DI
            builder.Services.AddAutoMapper(typeof(Program));



            #region JWT
            builder.Services.AddScoped(typeof(IToken), typeof(Token));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                }); 
            #endregion

            var app = builder.Build();

            #region UpdateDatabase
            using var Scope = app.Services.CreateScope(); // COntainer That Contain Services 
            var Services = Scope.ServiceProvider;  // these are Services 
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = Services.GetRequiredService<WorkoutTrackerDbContext>(); //this is Service I need   


                await dbContext.Database.MigrateAsync();

                await WorkoutTrackerContextSeed.SeedAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occured During Update Database");
            } 
            #endregion















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
        }
    }
}
