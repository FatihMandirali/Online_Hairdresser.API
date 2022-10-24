using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;

namespace Online_Hairdresser.API.Middleware
{
    public class ExceptionCatcherMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionCatcherMiddleware> _logger;

        public ExceptionCatcherMiddleware(ILogger<ExceptionCatcherMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Catch Middleware");
                await context.Response.WriteAsJsonAsync(new BaseResponse<object>(ProcessStatusEnum.InternalServerError,
                    new FriendlyMessage("Beklenmedik Hata Meydana Geldi")));
            }
        }
    }
}
