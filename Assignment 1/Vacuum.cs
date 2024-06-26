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
        public string Grade { get { return _grade; } set { _grade = value; } }
        public int Voltage { get { return _voltage; } set { _voltage = value; } }
        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int voltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _voltage = voltage;
        }


        public override string formatForFile()
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}Wattage: {Wattage}\n Colour: {Color}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {Voltage}\n";
        }
    }
}
