﻿using Assignment_1.Properties;
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
        public static void PrintMenu()
        {
            Console.Write("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:\r\n");
        }

        public static void BrandSearch(List<Appliance> appList)
        {
            Console.WriteLine("\n\nEnter brand to search for:");
            string brandName = Console.ReadLine();
            foreach (var app in appList)
            {
                if (app.Brand.ToLower() == brandName.ToLower())
                {
                    Console.WriteLine(app);
                }
            }
        }
        public static void ApplianceCheckout(List<Appliance> appList)
        {
            Console.WriteLine("Enter item number of an Appliance:");
            long userItemNum = long.Parse(Console.ReadLine());
            bool itemFound = false;
            foreach (var appliance in appList)
            {
                if (appliance.ItemNumber == userItemNum)
                {
                    itemFound = true;
                    if (appliance.isAvailable is false)
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                        break;
                    }
                    else
                    {
                        appliance.checkout();
                        // Console.WriteLine($"current applicance count is {appliance.Quantity}");
                    }
                    break;
                }
            }
            if (itemFound is false) { Console.WriteLine("No appliances found with that item number."); }
            Console.WriteLine("\n\n\n\n");
        }

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

            PrintMenu();
            int userInput = int.Parse(Console.ReadLine());

            while (userInput != 5)
            {
                switch(userInput)
                {
                    case 1:
                        ApplianceCheckout(appList);
                        break;
                    case 2:
                        BrandSearch(appList);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                PrintMenu();
                userInput = int.Parse(Console.ReadLine());
            }
        }
    }
}
