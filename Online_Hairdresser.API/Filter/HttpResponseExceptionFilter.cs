using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Exceptions;
using Online_Hairdresser.Models.Models.BaseModel;

namespace Online_Hairdresser.API.Filter;

public class HttpResponseExceptionFilter:IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var _stringLocalizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<Resource>>();
        var exceptionHandled = context.ExceptionHandled;
        context.ExceptionHandled = true;
        switch (context.Exception)
        {
            case ErrorException ex:
                context.Result = new ObjectResult(new BaseResponse<ModelStateDictionary>(ProcessStatusEnum.Error,
                    new FriendlyMessage(_stringLocalizer[ex.Message], _stringLocalizer[ex.Message]), null));
                break;
            case CheckUpdateException ex:
                var statusEnum = ex.Message == "MAJOR" ? ProcessStatusEnum.MajorUpdate : ProcessStatusEnum.MinorUpdate;
                context.Result = new ObjectResult(new BaseResponse<ModelStateDictionary>(statusEnum));
                break;
            default:
                context.ExceptionHandled = exceptionHandled;
                break;

        }
    }
}