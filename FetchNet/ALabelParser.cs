using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FetchNet
{
    public class ALabelParser : ILabelPraser
    {
        public   string Label
        {
            get; set;
        }

        public AddressCollection Prase<T>(string HtmlContent)
        {
            string regex = "href=[\\\"\\\'](http:\\/\\/|\\.\\/|\\/)?\\w+(\\.\\w+)*(\\/\\w+(\\.\\w+)?)*(\\/|\\?\\w*=\\w*(&\\w*=\\w*)*)?[\\\"\\\']";
            Regex re = new Regex(regex);
            MatchCollection matches = re.Matches(HtmlContent);
            System.Collections.IEnumerator enu = matches.GetEnumerator();
            while (enu.MoveNext() && enu.Current != null)
            {
                Match match = (Match)(enu.Current);
                Console.Write(match.Value + "\r\n");
            }
            return null;
        }
    }
}
