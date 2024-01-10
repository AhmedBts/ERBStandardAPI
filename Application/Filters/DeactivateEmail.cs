using Common;
using Domain.Common;
using Domain.Entities.SecurityModule.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Net.Mail;

namespace Application.Filters
{
    public class DeactivateEmail : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var db = svc.GetService<HUB_Context>();
            var userService = svc.GetService<IUserService>();
            var actionResult = filterContext.Result as ObjectResult;
            var val = actionResult!.Value as dynamic;
            if (val != 0)
            {
                var user = db.Users.Find(userService.GetUserId());
                #region Send E-mail
                var generalSetup = db.GeneralSetups.FirstOrDefault();

                MailMessage mailMessage = new MailMessage();
                var body = @$"<p>Hello, {user.Name}.</p>
                                 <br/>
                                 <p><b>We are sad to see you go.</b></p>
                                 <p>we received your request to deactivate your Eyeball account. Your account will be deactivated shortly.</p>
                                    <p>We hope to welcome you back soon!</p>
                                <br/>
                                    <p>Thanks,</p>                               
                                    <p>Eyeball team.</p>";
                mailMessage.SendSMTP(generalSetup!
                    ,subject: "Your Account will be deactivated"
                    ,mailAddresses:new string[] { user.Email! }
                    ,body: body);
                #endregion
            }
        }
    }
}
