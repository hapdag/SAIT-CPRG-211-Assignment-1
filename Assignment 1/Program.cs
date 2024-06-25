using Assignment_1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] fileData = Resources.appliances.Split('\n');
            foreach (String s in fileData) 
            {
                String[] applianceData = s.Split(';');
                Console.WriteLine(applianceData[0]); 
            }
        }
    }
}
