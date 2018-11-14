/**Program 1B
 * CIS 200-01
 * Due Date: 9/25/17
 * Grading ID: C6643
 * // This class is derived from the AirPackage class and creates an AirPackage called TwoDayAirPackage. This class introduces delivery type, and depending the delivery type chosen by the use, 
 * the cost of the package will change.**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    public class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver } // Enum for delivery type
        
        // TwoDayAirPackage Constructor
        public TwoDayAirPackage (Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery deliveryType)
            :base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }

        // 
        private Delivery DeliveryType
        {
            // Precondition: None
            // Postcondition: Value for delivery type will be returned
            get;

            // Precondition: None
            // Postcondition: Value for delivery type will be set to value
            set;
        }

        // Precondition: None
        // Postcondition: Cost will be returned and will be determined by the delivery type chosen
        public override decimal CalcCost()
        {
            decimal cost;
            decimal dlength = (decimal)Length;  // variable to hold length as a decimal
            decimal dwidth = (decimal)Width;    // variable to hold width as a decimal
            decimal dheight = (decimal)Height;  // variable to hold height as a decimal
            decimal dweigth = (decimal)Weight;  // variable to hold weight as a decimal

            
            if (DeliveryType == Delivery.Saver)
            {
                cost = .25m * (dlength + dwidth + dheight) + .25m * (dweigth);
                cost = cost * .9m;
            }
            else
                cost = .25m * (dlength + dwidth + dheight) + .25m * (dweigth);
            return cost;
        }

        // Precondition: None
        // Postcondition: A string with all of the values of the base class as well as the delivery type will be returned
        public override string ToString()
        {
            return base.ToString() +
            $"\nDelivery Type: {DeliveryType}";

        }




    }
}
