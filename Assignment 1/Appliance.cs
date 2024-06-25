using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal abstract class Appliance
    {
        private long _itemNumber;
        private string _brand;
        private int _quantity;
        private double _wattage;
        private string _color;
        private double _price;

        public long ItemNumber { get { return _itemNumber; } set { _itemNumber = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public double Wattage { get { return _wattage; } set { _wattage = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public double Price { get { return _price; } set { _price = value; } }

        public abstract bool isAvailable();
        public abstract void checkout();
        public abstract string formatForFile();
        public abstract string toString();


    }
}
