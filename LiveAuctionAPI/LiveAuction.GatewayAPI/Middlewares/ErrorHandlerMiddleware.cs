﻿using LiveAuction.Common.Helpers.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace LiveAuction.GatewayAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case HttpRequestException e:
                        response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new 
                { 
                    error?.Message,
                    error?.StackTrace
                });

                await response.WriteAsync(result);
            }
        }
    }
}
