using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTN_WebInterface_Inbox.Helper
{
    public class GeneralHelper
    {
        internal static bool GetTag(string TagName, string Content, out string Value)
        {
            try
            {
                Value = "";
                int startIndex = Content.IndexOf("<" + TagName, 0);
                if (startIndex == -1)
                {
                    Value = "$%$"; return false;
                }

                int endIndex = Content.IndexOf("/" + TagName + ">", startIndex);
                if (endIndex - startIndex < 0)
                {
                    Value = "$%$"; return false;
                    //show error
                    //Value = "{{!!Error tag=" + TagName + " Content=" + Content + " are incorrect!!}}";
                    // return false;
                }

                Value = Content.Substring(startIndex + 2 + TagName.Length, endIndex - startIndex - 3 - TagName.Length);
                Value = Value.Trim();
                return true;
            }
            catch (Exception ex) { Value = "$%$"; return false; }
        }
    }
}
