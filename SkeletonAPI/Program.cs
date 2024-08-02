using SkeletonAPI.DependencyInjection;
using System.Text.Json.Serialization;

namespace SkeletonAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
            // package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
            builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();

            builder.Services.RegisterServices(builder.Environment, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapHealthChecks("/healthz");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var logger = app.Services.GetService<ILogger<Program>>();
            logger?.LogInformation("Starting up api in {environment} mode", app.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT"));

            app.Run();
        }
    }
}
