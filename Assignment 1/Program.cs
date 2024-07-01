using Assignment_1.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {

        // print main menu to console
        public static void PrintMenu()
        {
            Console.Write("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\nEnter option:\r\n");
        }

        // searches and outputs appliances by user specified type and special features
        private static void SearchAppByType(List<Appliance> appList)
        {
            Console.Write("Appliance Types\r\n1 – Refrigerators\r\n2 – Vacuums\r\n3 – Microwaves\r\n4 – Dishwashers\r\nEnter type of appliance:\r\n");
            int userAppType = int.Parse(Console.ReadLine());

            // LINQ selections to make separate enumerate objects for different types of appliance object classes
            // query from appList and then cast into the correct child class type
            IEnumerable<Refrigerator> frigeList = from app in appList where app.ItemNumber.ToString().First() is '1' select (Refrigerator)app;
            IEnumerable<Vacuum> vacList = from app in appList where app.ItemNumber.ToString().First() is '2' select (Vacuum)app;
            IEnumerable<Microwave> micList = from app in appList where app.ItemNumber.ToString().First() is '3' select (Microwave)app;
            IEnumerable<Dishwasher> dishList = from app in appList where app.ItemNumber.ToString().First() is '4' || app.ItemNumber.ToString().First() is '5' select (Dishwasher)app;
            
            // generates output according to user input
            switch (userAppType)
            {
                case 1:
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int doorNum = int.Parse(Console.ReadLine());
                    if (doorNum > 4)
                    {
                        Console.WriteLine("Input exceeds possible number of doors\n");
                    }
                    else
                    {
                        Console.WriteLine("Matching refrigerators: ");
                        foreach (Refrigerator frige in frigeList)
                        {
                            if (frige.NumOfDoors == (Refrigerator.Doors)doorNum)
                            {
                                Console.WriteLine(frige);
                            }
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                    int volt = int.Parse(Console.ReadLine());
                    if (volt is 18 | volt is 24)
                    {
                        Console.WriteLine("Matching Vacuums: ");
                        foreach (Vacuum vacuum in vacList)
                        {
                            if (vacuum.BatVoltage == (Vacuum.Voltage)volt)
                            {
                                Console.WriteLine(vacuum);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid vacuum voltage\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                    string room = Console.ReadLine().ToUpper();
                    Dictionary<string,string> roomDict = new Dictionary<string, string>() { { "K","Kitchen" },{ "W","Work site" } };
                    if (roomDict.Keys.Contains(room))
                    {
                        Console.WriteLine("Matching microwaves: ");
                        foreach (Microwave mic in micList)
                        {
                            if (string.Equals(mic.RoomType, roomDict[room], StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(mic);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid room type entered.\n");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    string rating = Console.ReadLine();
                    rating = rating[0].ToString().ToUpper() + rating.Substring(1);
                    Dictionary<string, string> ratingDict = new Dictionary<string, string>() { { "Qt", "Quietest" }, { "Qr", "Quieter" }, { "Qu", "Quiet" }, { "M", "Moderate" } };
                    if (ratingDict.Keys.Contains(rating))
                    {
                        Console.WriteLine("Matching dishwashers:");
                        foreach (Dishwasher washer in dishList)
                        {
                            if (string.Equals(ratingDict[rating], washer.SoundRating, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(washer);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid sound rating entered.");
                    }
                    break;
            }
            Console.WriteLine("\n\n\n");
        }

        // outputs a list of random appliances according to the number from user input
        public static void RandomAppliance(List<Appliance> appList)
        {
            // make new random obj for random number generation
            Random rnd = new Random();
            Console.WriteLine("Enter number of appliances:");
            int inputNum = int.Parse(Console.ReadLine());
            if (inputNum > appList.Count())
            {
                Console.WriteLine("Error: Entered number exceeds total number of appliances in stock.\n");
            }
            else
            {
                // outputs user input number of random appliances
                Console.WriteLine("\nRandom appliances:");
                for (int i = 0; i < inputNum; i++)
                {
                    int rndNum = rnd.Next(0, appList.Count());
                    Console.WriteLine(appList[rndNum]);
                }
            }
        }

        // searchs appList for all appliances with user input brand name
        public static void BrandSearch(List<Appliance> appList)
        {
            Console.WriteLine("\nEnter brand to search for:");
            string brandName = Console.ReadLine();

            // LINQ statement to find brand names for all appliances in appList
            IEnumerable<string> allBrands = from app in appList select app.Brand.ToUpper();

            // iterates through the enumerable, outputs appliances matching user input brand if found
            if (allBrands.Contains(brandName.ToUpper()))
            {
                foreach (var app in appList)
                {
                    if ( string.Equals(brandName,app.Brand, StringComparison.OrdinalIgnoreCase) )
                    {
                        Console.WriteLine(app);
                    }
                }
            }
            else { Console.WriteLine("Appliance catalog does not contain this brand!\n"); }
            Console.WriteLine("\n\n\n");
        }

        // checks out appliances according to user input and appliance availablity
        public static void ApplianceCheckout(List<Appliance> appList)
        {
            Console.WriteLine("Enter item number of an Appliance:");
            long userItemNum = long.Parse(Console.ReadLine());
            bool itemFound = false;

            // iterates over appList for appliance with same itemID as user input
            // checks out the found item for user if appliance availablity returns true
            foreach (Appliance appliance in appList)
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
                    }
                    break;
                }
            }
            if (itemFound is false) { Console.WriteLine("No appliances found with that item number."); }
            Console.WriteLine("\n\n\n");
        }

        // Parses txt file and populates appList with child appliance objects
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
                            appList.Add(new Refrigerator(itemNumber, brand, quantity, wattage, colour, price, height, width, numOfDoors));
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
                            string feature = applianceData[6].Trim(), rating = applianceData[7].Trim();
                            appList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, colour, price, feature, rating));
                            break;
                        // case 5 of the switch case is a repeat of case 4 since itemID with leading 4s and 5s are both dishwashers
                        case '5':
                            string feature1 = applianceData[6].Trim(), rating1 = applianceData[7].Trim();
                            appList.Add(new Dishwasher(itemNumber, brand, quantity, wattage, colour, price, feature1, rating1));
                            break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // makes list of Appliance abstract type to store child appliance objects
            List<Appliance> appList = new List<Appliance>();
            
            // parses txt file and populate appList
            FileParse(appList);
            PrintMenu();
            int userInput = int.Parse(Console.ReadLine());
            while (userInput != 5)
            {
                switch(userInput)
                {
                    case 1:
                        // checks out appliance - see ApplianceCheckout local method for more info
                        ApplianceCheckout(appList);
                        break;
                    case 2:
                        // searches appliances by brand - see BrandSearch local method for more info
                        BrandSearch(appList);
                        break;
                    case 3:
                        // searches appliances by type - see SearchAppByType local method for more info
                        SearchAppByType(appList);
                        break;
                    case 4:
                        // outputs a list of random appliances - see RandomAppliance local method for more info
                        RandomAppliance(appList);
                        break;
                }
                PrintMenu();
                userInput = int.Parse(Console.ReadLine());
            }

            // Writes output into appliances.txt in resource folder
            // Uses AppDomain to find reletive current path for VS solution
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = string.Format("{0}Resources\\appliances.txt", Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var appliance in appList) 
                {
                    writer.WriteLine(appliance.formatForFile());
                }
            }
        }
    }
}
