using LiveAuction.Biddings.EventHandlers;
using LiveAuction.Biddings.Repositories;
using LiveAuction.Biddings.Services.DataReadServices;
using LiveAuction.Biddings.Services.DataWriteServices;
using LiveAuction.Biddings.Services.MongoDbService;
using MassTransit;
using MongoDB.Driver;

namespace LiveAuction.Biddings.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthorization()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

            builder.Services.AddScoped<IBiddingDataWriteService, BiddingDataWriteService>();
            builder.Services.AddScoped<IBiddingDataReadService, BiddingDataReadService>();
            builder.Services.AddScoped<IMongoDbService, MongoDbService>();
            builder.Services.AddScoped<IBiddingRepository, BiddingRepository>();
        }

        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(mongoConnectionString);
            var database = mongoClient.GetDatabase("biddings_db");

            builder.Services.AddSingleton<IMongoClient>(mongoClient);
            builder.Services.AddSingleton(database);
        }

        public static void RegisterRabbitMQ(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<EventsHandler>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ReceiveEndpoint("LiveAuction.Biddings", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<EventsHandler>(provider);
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
