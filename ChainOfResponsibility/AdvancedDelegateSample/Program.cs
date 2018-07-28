using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new FormatChecker();
            List<DataResult> results = new List<DataResult>();

            var dataSource = File.ReadAllLines("MemberList.csv", Encoding.Default);

            foreach (var item in dataSource)
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
