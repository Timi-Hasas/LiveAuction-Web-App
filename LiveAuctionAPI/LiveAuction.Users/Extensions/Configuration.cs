using LiveAuction.Users.EventHandlers;
using LiveAuction.Users.Repositories;
using LiveAuction.Users.Services.DataReadServices;
using LiveAuction.Users.Services.DataWriteServices;
using LiveAuction.Users.Services.MongoDbService;
using MassTransit;
using MongoDB.Driver;

namespace LiveAuction.Users.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthorization()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

            builder.Services.AddScoped<IUserDataWriteService, UserDataWriteService>();
            builder.Services.AddScoped<IUserDataReadService, UserDataReadService>();
            builder.Services.AddScoped<IMongoDbService, MongoDbService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(mongoConnectionString);
            var database = mongoClient.GetDatabase("users_db");

            builder.Services.AddSingleton<IMongoClient>(mongoClient);
            builder.Services.AddSingleton(database);
        }

        public static void RegisterRabbitMQ(this WebApplicationBuilder builder)
        {

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<UserEventHandler>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("LiveAuction.Users", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UserEventHandler>(provider);
                    });
                }));
            });
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI();
            }

            app.UseHttpsRedirection();
        }
    }
}
