using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Microwave : Appliance
    {
        private string _roomType;
        private double _capacity;

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, string roomType, double capacity) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _roomType = roomType;
            _capacity = capacity;
        }

        public override void checkout()
        {
            throw new NotImplementedException();
        }

        public override string formatForFile()
        {
            throw new NotImplementedException();
        }

        public override bool isAvailable()
        {
            throw new NotImplementedException();
        }

        public override string toString()
        {
            throw new NotImplementedException();
        }
    }
}
