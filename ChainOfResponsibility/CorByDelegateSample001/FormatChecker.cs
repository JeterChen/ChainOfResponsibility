using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorByDelegateSample001
{
    public class CheckResult
    {
        public string Source { get; set; }
        public bool Result { get; set; }


    }
    public class FormatChecker
    {
        List<Func<string, bool>> _checkers;

        public CheckResult Check(string source)
        {
            CreateCheckers();
            var isErrorDetected = _checkers.Any((x) => x.Invoke(source) == false);
            if (isErrorDetected)
            {
                return new CheckResult() { Source = source, Result = false };
            }
            else
            {
                return new CheckResult() { Source = source, Result = true };
            }
        }

        private void CreateCheckers()
        {
            if (_checkers == null)
            {
                _checkers = new List<Func<string, bool>>();

                _checkers.Add((x) => x.Length == 29);
                _checkers.Add((x) =>
                {
                    string head = x.Substring(0, 3);
                    return head == "965";
                });
                _checkers.Add((x) =>
                {
                    var dateString = x.Substring(13, 8);
                    DateTime date;
                    return DateTime.TryParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None, out date);
                });
                _checkers.Add((x) =>
                {
                    var dateString = x.Substring(21, 8);
                    DateTime date;
                    return DateTime.TryParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                                   System.Globalization.DateTimeStyles.None, out date);
                });
            }

        }
    }
}
