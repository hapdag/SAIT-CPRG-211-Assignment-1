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
                    string brand, colour;
                    double wattage, price;
                    long itemNumber;
                    int quantity;
                    itemNumber = long.Parse(applianceData[0].Trim());
                    brand = applianceData[1].Trim();
                    quantity = Int32.Parse(applianceData[2].Trim());
                    wattage = double.Parse(applianceData[3].Trim());
                    colour = applianceData[4].Trim();
                    price = double.Parse(applianceData[5].Trim());

                    switch (applianceData[0][0])
                    {
                        case '1':
                            int numOfDoors, height, width;
                            numOfDoors = Int32.Parse(applianceData[6].Trim());
                            height = Int32.Parse(applianceData[7].Trim());
                            width = Int32.Parse(applianceData[8].Trim());
                            appList.Add(new Refriderator(itemNumber,brand,quantity,wattage,colour,price,height,width,numOfDoors));
                            break;
                        case '2':

                            break;
                        case '3':
                            break;
                        case '4':
                            break;
                        case '5':
                            break;
                    }
                }
            }
            Console.WriteLine(appList.Count);
        }
    }
}
