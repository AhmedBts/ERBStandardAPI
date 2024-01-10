using Common;
using Domain;
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
    public class SendClientEmail : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var db = svc.GetService<HUB_Context>();
            var actionResult = filterContext.Result as ObjectResult;
            var val = actionResult!.Value as dynamic;
            if (val != null)
                if (val.Success)
                {

                    #region Send E-mail
                    var generalSetup = db.GeneralSetups.FirstOrDefault();

                    MailMessage mailMessage = new MailMessage();
                    var url = $"{GlobalVars.ClientUrl}/auth/UpdatePassword?email={SecurityLogic.Instance().EncryptString(val.Result.Email!)}";
                    var body = @$"<p>Verify your email, {val.Result.Name}.</p>
                                 <br/>
                                 <p>visit the following link and create your password</p>
                                    <b style='color:#002060'><a href='{url}'>{url}</a></b>
                                <br/>
                                  <p></p>
                                    <p>Best regards,</p>                               
                                    <p>Eyeball team.</p>";
                    mailMessage.SendSMTP(generalSetup!, subject: "Create Password"
                    , mailAddresses: new string[] { val.Result.Email! }
                    , body: body);
                    #endregion
                }
        }
    }
}
