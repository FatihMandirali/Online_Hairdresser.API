using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;

namespace Online_Hairdresser.API.Extensions
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _stringLocalizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<Resource>>();

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Any())
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .FirstOrDefault()??"bad_Request";

                var responseObj = new BaseResponse<object>(ProcessStatusEnum.BadRequest, new FriendlyMessage { Message = _stringLocalizer[errors] }, null);


                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }
    }
}
