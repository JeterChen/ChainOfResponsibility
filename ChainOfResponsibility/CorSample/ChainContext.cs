using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorSample
{
    public class ChainContext
    {
        public static FormatChecker GetCheckers()
        {
            return new LengthChecker(new HeadChecker(new FirstDateChecker(new SecondDateChecker(null))));
        }
    }
}
