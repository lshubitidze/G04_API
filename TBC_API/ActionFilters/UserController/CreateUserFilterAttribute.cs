using Fasade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace TBC_API.ActionFilters.UserController
{
    public class CreateUserFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.ActionArguments["user"] as UserModel;

            if (user == null)
                context.Result = new BadRequestObjectResult(user);

            if (user.UserName.Length < 2 || user.UserName.Length > 50)
                context.Result = new BadRequestObjectResult(new { errorMessage = "Username Length must be between 2 and 50 charaqters" });

            if (!Regex.IsMatch(user.UserName, @"^[a-z.A-Z]+$|^[ა-ჰ]+$"))
                context.Result = new BadRequestObjectResult(new { errorMessage = "Username must include only English or Georgian letters" });

            if (!Regex.IsMatch(user.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                context.Result = new BadRequestObjectResult(new { errorMessage = "Incorrect Email format" });
        }
    }
}
