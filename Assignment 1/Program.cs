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
        public static void FileParse(List<Appliance> appList)
        {
            String[] fileData = Resources.appliances.Split('\n');
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
                            appList.Add(new Refriderator(itemNumber, brand, quantity, wattage, colour, price, height, width, numOfDoors));
                            break;
                        case '2':
                            string grade = applianceData[6].Trim();
                            int voltage = Int32.Parse(applianceData[7].Trim());
                            appList.Add(new Vacuum(itemNumber, brand, quantity, wattage, colour, price, grade, voltage));
                            break;
                        case '3':
                            double capacity = double.Parse(applianceData[6].Trim());
                            string roomType = applianceData[7].Trim();
                            appList.Add(new Microwave(itemNumber, brand, quantity, wattage, colour, price, roomType, capacity));
                            break;
                        case '4':
                            string rating = applianceData[6].Trim(), feature = applianceData[7].Trim();
                            appList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, colour, price, feature, rating));
                            break;
                        case '5':
                            string rating1 = applianceData[6].Trim(), feature1 = applianceData[7].Trim();
                            appList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, colour, price, feature1, rating1));
                            break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<Appliance> appList = new List<Appliance>();
            FileParse(appList);
            foreach (var item in appList)
            {
                Console.WriteLine(item.GetType());
            }
        }
    }
}
