using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorSample
{
    public class CheckResult
    {
        public string Source { get; set; }
        public bool Result { get; set; }


    }

    public abstract class FormatChecker
    {
        protected FormatChecker _successor;
        protected abstract bool InternalCheck(string source);
        public CheckResult Check(string source)
        {
            // 檢查結果為 true, 若沒有後繼者,表示檢查結束, 若有後繼者則繼續往下處理
            // 檢查結果為 false, 則跳出, 不再處理
            if (InternalCheck(source))
            {
                if (_successor != null)
                {
                    return _successor.Check(source);
                }
                else
                {
                    return new CheckResult() { Source = source, Result = true };
                }
            }
            else
            {
                return new CheckResult() { Source = source, Result = false };
            }
        }

        protected FormatChecker(FormatChecker successor)
        {
            _successor = successor;
        }
    }

    /// <summary>
    /// 長度檢查
    /// </summary>
    internal class LengthChecker : FormatChecker
    {
        public LengthChecker(FormatChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(string source)
        {
            return source.Length == 29;
        }
    }

    /// <summary>
    /// 開頭檢查
    /// </summary>
    internal class HeadChecker : FormatChecker
    {

        public HeadChecker(FormatChecker successor) : base(successor)
        {

        }

        protected override bool InternalCheck(string source)
        {

            string head = source.Substring(0, 3);
            return head == "965";

        }
    }

    /// <summary>
    /// 第一個日期檢查
    /// </summary>
    internal class FirstDateChecker : FormatChecker
    {
        public FirstDateChecker(FormatChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(string source)
        {
            var dateString = source.Substring(13, 8);
            DateTime date;
            return DateTime.TryParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out date);
        }
    }

    /// <summary>
    /// 第二個日期檢查
    /// </summary>
    internal class SecondDateChecker : FormatChecker
    {
        public SecondDateChecker(FormatChecker successor) : base(successor)
        {
        }

        protected override bool InternalCheck(string source)
        {
            var dateString = source.Substring(21, 8);
            DateTime date;
            return DateTime.TryParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out date);
        }
    }
}
