using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSender
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLSender xmlSender = new XMLSender(420);
            xmlSender.start();
            Console.ReadLine();
        }
    }
}
