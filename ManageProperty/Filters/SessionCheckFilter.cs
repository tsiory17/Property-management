using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ManageProperty.Filters
{
    public class SessionCheckFilter : ActionFilterAttribute
    {
        private readonly string[] _roles;
        public SessionCheckFilter(params string[] roles)
        {
            _roles = roles;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext.Session.GetString("UserName");
            var userRole = context.HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userRole) || !_roles.Contains(userRole))
            {
                context.Result = new RedirectToActionResult("Index", "Account", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
