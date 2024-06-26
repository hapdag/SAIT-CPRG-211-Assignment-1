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
        public string Feature { get { return _feature; } set { _feature = value; } }
        public string SoundRating { get { return _soundRating; } set { _soundRating = value; } }
        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _feature = feature;
            _soundRating = soundRating;
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
