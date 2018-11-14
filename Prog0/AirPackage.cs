/**Program 1B
 * CIS 200-01
 * Due Date: 9/25/17
 * Grading ID: C6643
 * This class creates an AirPackage which is derived from the Package class. This class introduces two new values Heavy and Large. The weight and size of the package determines the whether the package
 * is classified as heavy and/or large.**/
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    public abstract class AirPackage : Package
    {
        // Constructor which calls the base class
        public AirPackage (Address originAddress, Address destAddress, double length, double width, double height, double weight)
            :base(originAddress,destAddress,length,width,height,weight)
        {
        }

        // Precondition: None
        // Postcondition: Returns a true value if the package is classified as heavy, else it returns false
        public bool IsHeavy()
        {
            if (Weight >= 75)
                return true;
            else
                return false;
        }

        // Precondition: None
        // Postcondition: Returns a true value if the package is classified as large, else it returns false
        public bool IsLarge()
        {
            double size = (Length + Width + Height);

            if (size >= 100)
                return true;
            else
                return false;
        }

        // Precondition: None
        // Postcondition: Returns a string that includes the base class values as well as the GroundPackage's heavy/large classification
        public override string ToString()
        {
            if (IsHeavy())
            {
                return base.ToString() +
                $"\nIs it classified heavy: Yes";
            }
            else
            {
                return base.ToString() +
                    $"\nIs it classified heavy: No";
            }
            
        }
    }
}
