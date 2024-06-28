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
        private Voltage _voltage;
        public string Grade { get { return _grade; } set { _grade = value; } }
        public Voltage BatVoltage { get { return _voltage; } }
        public enum Voltage
        {
            Low = 18, High = 24
        }
        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int voltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _voltage = (Voltage)voltage;
        }


        public override string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{_grade};{(int)_voltage};";
        }


        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Color}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {BatVoltage}\n";
        }
    }
}
