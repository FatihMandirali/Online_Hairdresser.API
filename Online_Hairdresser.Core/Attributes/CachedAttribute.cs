﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly bool _isItUserSpesific;
        private int _expireTimeSeconds;

        public CachedAttribute(bool isItUserSpesific = false, int expireTimeSeconds = 0)
        {
            _expireTimeSeconds = expireTimeSeconds;
            _isItUserSpesific = isItUserSpesific;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<CacheSettings>();
            if (_expireTimeSeconds <= 0) _expireTimeSeconds = cacheSettings.ResponseCacheExpireTimeSeconds;
            
            //var responseCacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            //var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext, _isItUserSpesific);
            //var cacheResponse = responseCacheService.Get(cacheKey); // InMemoryCache
            
            var responseCacheService = context.HttpContext.RequestServices.GetRequiredService<IRedisCacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext, _isItUserSpesific);
            var cacheResponse = await responseCacheService.GetValueAsync(cacheKey);

            if (cacheResponse != null)
            {
                var contentResult = new ContentResult
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var executedContext = await next();
            var result = executedContext.Result as ObjectResult;
            var res = result?.Value;
            await responseCacheService.SetValueAsync(cacheKey, JsonSerializer.Serialize(res));
        }

        private static string GenerateCacheKeyFromRequest(HttpContext httpContext, bool isItUserSpesific)
        {
            var request = httpContext.Request;

            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.PathBase}");
            keyBuilder.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
