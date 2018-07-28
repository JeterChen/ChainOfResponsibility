using FakeDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorByDelegateSample001
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new FormatChecker();
            List<CheckResult> results = new List<CheckResult>();
            foreach (var item in FakeDataSource.Data)
            {
                results.Add(checker.Check(item));
            }

            foreach (var item in results)
            {
                Console.WriteLine($"Source : {item.Source } , Result ={item.Result}");
            }
            Console.ReadLine();
        }
    }
}
