
using ApplicationLayer;
using InfrastructureLayer.Data;

namespace CQRS_MediatR_Hangfire_RappitMQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddProblemDetails();// register problem details service
            builder.Services.AddInfrastructure(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(); // Uses Problem Details by default when service is registered
            app.UseStatusCodePages(); // Converts 404/405/etc. to Problem Details JSON

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
