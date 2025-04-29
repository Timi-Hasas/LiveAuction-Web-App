
using LiveAuction.Auctions.Endpoints;
using LiveAuction.Auctions.Extensions;

namespace LiveAuction.Auctions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.RegisterServices();
            builder.RegisterRabbitMQ();
            builder.RegisterDatabase();

            var app = builder.Build();

            app.RegisterMiddlewares();
            app.RegisterEndpoints();

            app.Run();
        }
    }
}