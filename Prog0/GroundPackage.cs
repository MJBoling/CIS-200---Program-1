/**Program 1B
 * CIS 200-01
 * Due Date: 9/25/17
 * Grading ID: C6643
 * This class is dervied from the Package class. It has a ZoneDistance property which determines the distance between two zip codes. **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    public class GroundPackage : Package
    {
        // Constructor which calls the base class
        public GroundPackage (Address originAddress, Address destAddress, double length, double width, double height, double weight)
            :base(originAddress, destAddress, length, width, height, weight)
        {

        }
        // Precondition: None
        // Postcondition: The GroundPackage's cost has been returned
        public override decimal CalcCost()
        {
            decimal cost;
            decimal dlength = (decimal)Length;  // variable to hold length as a decimal
            decimal dwidth = (decimal)Width;    // variable to hold width as a decimal
            decimal dheight = (decimal)Height;  // variable to hold height as a decimal
            decimal dweigth = (decimal)Weight;  // variable to hold weight as a decimal

            cost = .20m *(dlength + dwidth + dheight) + .10m * (ZoneDistance + 1) * dweigth;
            return cost;
        }
        
        private int ZoneDistance
        {
            // Precondition:  None
            // Postcondition: The ground package's zone distance is returned.
            //                The zone distance is the positive difference between the
            //                first digit of the origin zip code and the first
            //                digit of the destination zip code.
            get
            {
                const int FIRST_DIGIT_FACTOR = 10000; // Denominator to extract 1st digit
                int diff;                             // Calculated zone difference

                diff = (OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR);

                return Math.Abs(diff); // Absolute value in case negative
            }
        }

        // Precondition: None
        // Postcondition: A string is returned with the base class's values as well as the zone distance
        public override string ToString()
        {
            return base.ToString() +
            $"\nZone Distance:{ZoneDistance}";
        }

    }
}
