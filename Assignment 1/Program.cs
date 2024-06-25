using Assignment_1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] fileData = Resources.appliances.Split('\n');
            List<Appliance> appList = new List<Appliance>();
            foreach (String s in fileData) 
            {
                if (String.IsNullOrEmpty(s))
                {
                    continue;
                }
                else
                {
                    String[] applianceData = s.Split(';');
                    switch (applianceData[0][0])
                    {
                        case '1':
                            Console.WriteLine("fridge");
                            break;
                        case '2':
                            Console.WriteLine("Vacuum");
                            break;
                        case '3':
                            Console.WriteLine("Microwave");
                            break;
                        case '4':
                            Console.WriteLine("Dishwasher");
                            break;
                        case '5':
                            Console.WriteLine("Dishwasher");
                            break;
                    }
                }
            }
        }
    }
}
