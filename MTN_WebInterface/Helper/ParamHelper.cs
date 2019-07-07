using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTN_WebInterface_Inbox.Helper
{
    public static class ParamHelper
    {
      

        internal static Dictionary<string, string> notifySmsReceipt = new Dictionary<string, string>()
        {
            ["$<soapenv:Header>$<ns1:spId>$"] = "$SpID$",
            ["$<soapenv:Header>$<ns1:serviceId>$"] = "$ServiceId$",
            ["$<soapenv:Header>$<ns1:timeStamp>$"] = "$TimeStamp$",
            ["$<soapenv:Header>$<ns1:linkid>$"] = "$Linkid$",
            ["$<soapenv:Body>$<ns2:correlator>$"] = "$Correlator$",
            ["$<soapenv:Body>$<ns2:message>$<message>$"] = "$Content$",
            ["$<soapenv:Body>$<ns2:message>$<senderAddress>$"] = "$Sender$",
            ["$<soapenv:Body>$<ns2:message>$<smsServiceActivationNumber>$"] = "$ShortCode$",
            ["$<soapenv:Body>$<ns2:message>$<dateTime>$"] = "$TimeSpan$"
        };

      
        internal static Dictionary<string,string> GetParam(string SoapData, Dictionary<string, string> Pattern)
        {
            Dictionary<string, string> BodyElement = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> Node in Pattern)
            {
                string content = SoapData;
                string[] tags = Node.Key.Split('$');

                for (int i = 1; i < tags.Length - 1; i++)
                {
                    tags[i] = tags[i].Replace("<", "");
                    tags[i] = tags[i].Replace(">", "");
                    GeneralHelper.GetTag(tags[i], content, out content);
                }
                if (content != "$%$")
                    BodyElement.Add(Node.Value, content);
            }
            return BodyElement;
        }
    }
}
