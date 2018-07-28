using FakeDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = ChainContext.GetCheckers();
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
