using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Refriderator : Appliance
    {
        private int _height;
        private int _width;
        private int _numOfDoors;
        public int Height { get { return _height; } set { _height = value; } }
        public int Width { get { return _width; }set { _width = value; } }
        public int NumOfDoors { get { return _numOfDoors; } set { _numOfDoors = value; } }
        public Refriderator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int height, int width, int numOfDoors) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _height = height;
            _width = width;
            _numOfDoors = numOfDoors;
        }

        public override void checkout()
        {
            throw new NotImplementedException();
        }

        public override string formatForFile()
        {
            throw new NotImplementedException();
        }

        public override string toString()
        {
            throw new NotImplementedException();
        }
    }
}
