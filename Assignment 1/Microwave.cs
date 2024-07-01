using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Microwave : Appliance
    {
        private string _roomType;
        private double _capacity;

        // RoomType property returns descriptive room types when called
        public string RoomType { 
            get
            {
                if (string.Equals(_roomType,"w", StringComparison.OrdinalIgnoreCase)) { return "Work site"; } else { return "Kitchen"; } 
            } 
            set 
            { _roomType = value; } }
        public double Capacity { get { return _capacity; }set { _capacity = value; } }
        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, string roomType, double capacity) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _roomType = roomType;
            _capacity = capacity;
        }


        public override string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{_capacity};{_roomType};";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Color}\nPrice: {Price}\nCapacity: {Capacity}\nRoom Type: {RoomType}\n";
        }
    }
}
