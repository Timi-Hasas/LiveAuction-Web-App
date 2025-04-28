using LiveAuction.Users.Endpoints;
using LiveAuction.Users.Extensions;

namespace LiveAuction.Users
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
            app.RegisterUserEndpoints();

            app.Run();
        }
    }
}