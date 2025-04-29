using LiveAuction.Auctions.EventHandlers;
using LiveAuction.Auctions.Repositories;
using LiveAuction.Auctions.Services.DataReadServices;
using LiveAuction.Auctions.Services.DataWriteServices;
using LiveAuction.Auctions.Services.MongoDbService;
using MassTransit;
using MongoDB.Driver;

namespace LiveAuction.Auctions.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthorization()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

            builder.Services.AddScoped<IAuctionDataWriteService, AuctionDataWriteService>();
            builder.Services.AddScoped<IAuctionDataReadService, AuctionDataReadService>();
            builder.Services.AddScoped<IMongoDbService, MongoDbService>();
            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
        }

        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(mongoConnectionString);
            var database = mongoClient.GetDatabase("auctions_db");

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
                    cfg.ReceiveEndpoint("LiveAuction.Auctions", ep =>
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

