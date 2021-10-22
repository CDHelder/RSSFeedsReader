using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RSSService service = new RSSService();
            var data = service.GetRSSData();
            System.Console.WriteLine(data);
            System.Console.ReadLine();
        }
    }
}
