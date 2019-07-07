using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MTN_WebInterface_Inbox.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpPost("SMS/MOSmsSoapServer.asmx/notifySmsReception")]
        //[Route("notifySmsReception")]
        public ActionResult notifySmsReceipt()
        {
            string reply = Helper.ReplyHelper.notifySmsReceiptReply.Replace("$notifySmsReceiptResponse$", "OK");

            try
            {
                //
                System.IO.StreamReader reader = new System.IO.StreamReader(HttpContext.Request.Body);
                string SoapData = reader.ReadToEnd();
                //find body elman
                Dictionary<string, string> BodyElement = Helper.ParamHelper.GetParam(SoapData, Helper.ParamHelper.notifySmsReceipt);

                //put on db
                using (var dbcontext = new DB.NegarDBContext())
                {
                    dbcontext.TInboxMtn.Add(new DB.TInboxMtn()
                    {
                        //Id auto increment
                        Request = SoapData,
                        SpId = BodyElement.ContainsKey("SpID") ? BodyElement["SpID"] : "",
                        ServiceId = BodyElement.ContainsKey("ServiceId") ? BodyElement["ServiceId"] : "",
                        TimeStamp = BodyElement.ContainsKey("TimeStamp") ? BodyElement["TimeStamp"] : "",
                        Linkid = BodyElement.ContainsKey("Linkid") ? BodyElement["Linkid"] : "",
                        Correlator = BodyElement.ContainsKey("Correlator") ? BodyElement["Correlator"] : "",
                        Content = BodyElement.ContainsKey("Content") ? BodyElement["Content"] : "",
                        Sender = BodyElement.ContainsKey("Sender") ? BodyElement["Sender"] : "",
                        Shortcode = BodyElement.ContainsKey("ShortCode") ? BodyElement["ShortCode"] : "",
                        TimeSpan = BodyElement.ContainsKey("TimeSpan") ? BodyElement["TimeSpan"] : "",
                        Media = "SMS",
                        CreateDate = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                reply = Helper.ReplyHelper.notifySmsReceiptReply.Replace("$notifySmsReceiptResponse$", "Error");
                Log.Fatal(ex, "Exception(notifySmsReceipt): {@Exception}", ex);
            }

            return Ok(reply);
        }
       
    }
}