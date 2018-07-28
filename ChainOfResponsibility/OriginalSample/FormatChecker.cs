using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalSample
{
    public class CheckResult
    {
        public string Source { get; set; }
        public bool Result { get; set; }


    }
    public class FormatChecker
    {
        public CheckResult Check(string source)
        {
            var result = new CheckResult() { Source = source };
            
            if (source.Length == 29)
            {
                if (source.Substring (0,3) == "965")
                {
                    DateTime firstDate;
                    if (DateTime.TryParseExact (source.Substring(13, 8) , "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out firstDate ) )
                    {
                        DateTime secondDate;
                        if (DateTime.TryParseExact(source.Substring(21, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out secondDate))
                        {
                            result.Result = true;
                        }

                    }
                }
            }

            return result;
        }
    }
}
