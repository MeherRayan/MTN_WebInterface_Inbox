using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTN_WebInterface_Inbox.Helper
{
    public static class ReplyHelper
    {
        internal static string notifySmsReceiptReply = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:loc=\"http://www.csapi.org/schema/parlayx/sms/notification/v2_2/local\">" +
                   " <soapenv:Header/>" +
                   " <soapenv:Body>" +
                   " <loc:$notifySmsReceiptResponse$/>" +
                   " </soapenv:Body>" +
                   " </soapenv:Envelope>";

    }
}
