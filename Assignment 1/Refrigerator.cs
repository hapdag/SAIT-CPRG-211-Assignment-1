using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Refrigerator : Appliance
    {
        private int _height;
        private int _width;
        private int _numOfDoors;
        public int Height { get { return _height; } set { _height = value; } }
        public int Width { get { return _width; }set { _width = value; } }
        public int NumOfDoors { get { return _numOfDoors; } set { _numOfDoors = value; } }
        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int height, int width, int numOfDoors) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _height = height;
            _width = width;
            _numOfDoors = numOfDoors;
        }


        public override string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumOfDoors};{Height};{Width};\n";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Color}\nPrice: {Price}\nNumber of Doors: {NumOfDoors}\nHeight: {Height}\nWidth: {31}\n";
        }
    }
}
