using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDelegateSample
{
    public static class MemberUtilities
    {
        public static Members ChangeMember(this string[] sarray)
        {
            Members result = new Members();

            result.Name = sarray[0];
            result.Phone = sarray[1];
            result.Email = sarray[2];

            return result;


        }
    }
}
