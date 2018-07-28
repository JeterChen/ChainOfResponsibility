using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDelegateSample
{
    public class FormatChecker
    {
        List<Func<string, Members, bool>> _checks;

        public DataResult Check(string source)
        {
            Members obj = new Members();
            var m_array = source.Split(',');
            CreateCheckers();
            return (_checks.Any((c) => c.Invoke(source, obj) == false) ?
                 new DataResult() { Source = source, Member = m_array.ChangeMember(), Result = false } :
               new DataResult() { Source = source, Member = m_array.ChangeMember(), Result = true });
        }

        private void CreateCheckers()
        {
            _checks = new List<Func<string, Members, bool>>();

            //姓名必須大於2個字元
            _checks.Add((x, y) =>
            {
                var sourcestr = x.Split(',');
                y = sourcestr.ChangeMember();
                return y.Name.Length > 2;
            });
            //手機號碼必須長度為10碼
            _checks.Add((x, y) =>
            {
                var sourcestr = x.Split(',');
                y = sourcestr.ChangeMember();

                return y.Phone.Length == 10;
            });
            //手機號碼必須開頭為09
            _checks.Add((x, y) =>
            {
                var sourcestr = x.Split(',');
                y = sourcestr.ChangeMember();

                return y.Phone.StartsWith("09");
            });
            //驗證是否為Email格式
            _checks.Add((x, y) =>
            {
                var sourcestr = x.Split(',');
                y = sourcestr.ChangeMember();
                return y.Email.IsValidEmail();
            });
        }
    }
}
