using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;

namespace Online_Hairdresser.API.Middleware;

public class ExceptionCatcherMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionCatcherMiddleware> _logger;
    private readonly IStringLocalizer<Resource> _stringLocalizer;

    public ExceptionCatcherMiddleware(ILogger<ExceptionCatcherMiddleware> logger, IStringLocalizer<Resource> stringLocalizer)
    {
        _logger = logger;
        _stringLocalizer = stringLocalizer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Occured");
            await context.Response.WriteAsJsonAsync(new BaseResponse<object>(ProcessStatusEnum.Error,
                new FriendlyMessage("",_stringLocalizer["unexpected_error"])));
        }
    }
}