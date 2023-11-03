using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT; //TGMT = Cong ty Thi Giac May Tinh

namespace ExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PlateReader reader = new PlateReader();

            PlateInfo plate = reader.Read(@"20151006120042_103.jpg");

            Console.WriteLine(plate.text);
            Console.WriteLine(plate.alphanumeric);

            Console.ReadLine();
        }
    }
}
