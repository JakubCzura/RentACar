using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services;
using RentACar.WebAPI.Services.Interfaces;
using RentACar.WebAPI.Validators;

namespace RentACar.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000", "https://localhost:7216/Account/Login")
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod(); // add the allowed origins
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RentACarDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RentACarDbContextConnectionString")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IPickupLocationRepository, PickupLocationRepository>();
            builder.Services.AddScoped<IPickupLocationService, PickupLocationService>();
            builder.Services.AddScoped<IDropoffLocationRepository, DropoffLocationRepository>();
            builder.Services.AddScoped<IDropoffLocationService, DropoffLocationService>();
            builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            builder.Services.AddScoped<IValidator<LogInUserDto>, LogInUserDtoValidator>();

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
            app.UseCors(MyAllowSpecificOrigins);
            app.Run();
        }
    }
}