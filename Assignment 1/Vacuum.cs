using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Vacuum : Appliance
    {
        private string _grade;
        private int _voltage;

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int voltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _voltage = voltage;
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
