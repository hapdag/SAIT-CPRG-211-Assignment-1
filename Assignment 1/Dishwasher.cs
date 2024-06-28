using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Dishwasher : Appliance
    {
        private string _feature;
        private string _soundRating;
        public string Feature { get { return _feature; } }
        public string SoundRating { 
            get 
            { 
                if (_soundRating is "Qt") { return "Quietest"; }
                else if (_soundRating is "Qr") { return "Quieter"; }
                else if ( _soundRating is "Qu") { return "Quiet"; }
                else { return "Moderate"; }
            } 
        }
        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _feature = feature;
            _soundRating = soundRating;
        }

        public override string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{_feature};{_soundRating};";

        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Color}\nPrice: {Price}\nFeature: {Feature}\nSound Rating: {SoundRating}\n";
        }
    }
}
