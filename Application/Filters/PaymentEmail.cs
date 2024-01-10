using Common;
using Domain.Entities.SecurityModule.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class PaymentEmail : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var db = svc.GetService<HUB_Context>();
            var userService = svc.GetService<IUserService>();
            var actionResult = filterContext.Result as ObjectResult;
            var val = actionResult!.Value as dynamic;

                var user = db.Users.Find(userService.GetUserId());
            if (val == 0)
            {
                #region Send E-mail
                var generalSetup = db.GeneralSetups.FirstOrDefault();

                MailMessage mailMessage = new MailMessage();
                var body = @$"<p>Hello, {user.Name}.</p>
                                 <br/>
                                 <p>Unfortunately, we were unable to charge your card ending in 1234 for your Eyeball reservation, due to insufficient funds in your account.</p>

                                <br/>
                                    <p>Thanks,</p>                               
                                    <p>Eyeball team.</p>";
                mailMessage.SendSMTP(generalSetup!
                    , subject: "Unsuccessfull Payment"
                    , mailAddresses: new string[] { user.Email! }
                    , body: body);
                #endregion
            }
            else if(val == 1)
            {
                #region Send E-mail
                var generalSetup = db.GeneralSetups.FirstOrDefault();

                MailMessage mailMessage = new MailMessage();
                var body = @$"<p>Hello, {user.Name}.</p>
                                 <br/>
                                 <p>Unfortunately, an error has occurred, and your payment cannot be processed at this time, please verify your card details, or try again later.</p>

                                <br/>
                                    <p>Thanks,</p>                               
                                    <p>Eyeball team.</p>";
                mailMessage.SendSMTP(generalSetup!
                    , subject: "Unsuccessfull Payment"
                    , mailAddresses: new string[] { user.Email! }
                    , body: body);
                #endregion

            }
            else if(val == 2)
            {
                #region Send E-mail
                var generalSetup = db.GeneralSetups.FirstOrDefault();

                MailMessage mailMessage = new MailMessage();
                var body = @$"<p>Hello, {user.Name}.</p>
                                 <br/>
                                 <p>Your payment is successful and your booking at Eyeball is confirmed.</p>

                                <br/>
                                <table style=""width:100%"">
                                <tr><td><b>Date:</b></td><td colspan=""2"">ttttttttttttttttttttttttttttt</td><td></td><td><b>Location:</b></td><td>ttttt</td></tr> 
                                <tr><td><b>Duration:</b></td><td colspan=""2"">ttttttttttttttttttttttttttttt</td><td></td><td><b>Court:</b></td><td>ttttt</td></tr> 
                                <tr><td><b>Price:</b></td><td colspan=""2"">ttttttttttttttttttttttttttttt</td><td></td><td><b>Reference Number:</b></td><td>ttttt</td></tr> 
                                </table>
                                    <p>Thanks,</p>                               
                                    <p>Eyeball team.</p>";
                mailMessage.SendSMTP(generalSetup!
                    , subject: "Successful Payment"
                    , mailAddresses: new string[] { user.Email! }
                    , body: body);
                #endregion

            }
        }
    }
}
