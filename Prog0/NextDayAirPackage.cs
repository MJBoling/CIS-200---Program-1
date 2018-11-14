/**Program 1B
 * CIS 200-01
 * Due Date: 9/25/17
 * Grading ID: C6643
 * This class is derived from the AirPackage class. The calccost will return different prices depending on whether the package is classified as heavy and or large.**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    public class NextDayAirPackage : AirPackage
    {
        // constructor for NextDayAirPackage
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        public decimal ExpressFee
        {
            // Precondition: None
            // Postcondition: Value for ExpressFee will be returned
            get;
        }

        // Precondition: None
        // Postcondition: The AirPackage's cost has been returned
        public override decimal CalcCost()
        {
            decimal dlength = (decimal)Length;  // variable to hold length as a decimal
            decimal dwidth = (decimal)Width;    // variable to hold width as a decimal
            decimal dheight = (decimal)Height;  // variable to hold height as a decimal
            decimal dweight = (decimal)Weight;  // variable to hold weight as a decimal

            decimal cost = .40m * (dlength + dwidth + dheight) + .30m * (dweight) + ExpressFee;
            if (IsHeavy())
                cost += .25m * (dweight);
            if (IsLarge())
                cost += .25m + (dlength + dwidth + dheight);

            return cost;
        }

        // Precondition: none
        // Postcondition: The values will be returned as a string
        public override string ToString()
        {
            return base.ToString();

        }

    }
}
