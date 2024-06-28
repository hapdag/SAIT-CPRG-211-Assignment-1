﻿using System;
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
        public string RoomType { get { return _roomType; } set { _roomType = value; } }
        public double Capacity { get { return _capacity; }set { _capacity = value; } }
        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, string roomType, double capacity) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _roomType = roomType;
            _capacity = capacity;
        }


        public override string formatForFile()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\n Colour: {Color}\nPrice: {Price}\nCapacity: {Capacity}\nRoom Type: {RoomType}\n";
        }
    }
}
