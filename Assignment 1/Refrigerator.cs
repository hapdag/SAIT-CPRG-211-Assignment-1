using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Refrigerator : Appliance
    {
        private int _height;
        private int _width;
        private Doors _numOfDoors;
        
        // enum type for doors, each door type is indexed according to the number of doors they are assigned
        public enum Doors
        {
            Double = 2,
            Three = 3,
            Four = 4,
        }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }
        public Doors NumOfDoors { get { return _numOfDoors; } }
        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int height, int width, int numOfDoors) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _height = height;
            _width = width;
            _numOfDoors = (Doors)numOfDoors;
        }


        public override string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{(int)_numOfDoors};{_height};{_width};";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Color}\nPrice: {Price}\nNumber of Doors: {NumOfDoors} Doors\nHeight: {Height}\nWidth: {Width}\n";
        }
    }
}
