namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public static class UserEndpoints
    {
        public static string GetUsersEndpoint() 
            => $"{ServiceHost.UsersAPI}/api/v1/users";

        public static string GetUserEndpoint(Guid userId) 
            => $"{ServiceHost.UsersAPI}/api/v1/users/{userId}";

        public static string GetUserByEmailEndpoint(string email)
            => $"{ServiceHost.UsersAPI}/api/v1/users/filter?email={email}";
    }
}
