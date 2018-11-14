/**Program 1B
 * CIS 200-01
 * Due Date: 9/25/17
 * Grading ID: C6643
 * The package class is derived from the Parcel class. This class introduces the length, width, height, and weight properties.**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    public abstract class Package : Parcel
    {
        private double _length; // Package length
        private double _width;  // Package width
        private double _height; // Package height
        private double _weight; // Package weight

        // Precondition: None
        // Postcondition: The package is created with the specified values
        public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            :base (originAddress, destAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight; 
        }

        public double Length
        {
            // Precondition: None
            // Postcondition: The package's length has been returned
            get
            {
                return _length;
            }

            // Precondition: Value is greater than or equal to 0
            // Postcondition: Length has been set equal to the value
            set
            {
                if (value >= 0)
                    _length = value;
                else
                    throw new ArgumentOutOfRangeException("Length must be a positive number");
             }
        }

        public double Width
        {
            //Precondition: None
            // Postcondition: The package's width has been returned
            get
            {
                return _width;
            }

            // Precondition: None
            // Postcondition: The package's width has been set to the specified value
            set
            {
                if (value >= 0)
                    _width = value;
                else
                    throw new ArgumentOutOfRangeException("Width must be a positive number");
            }
        }

        public double Height
        {
            // Precondition: None
            // Postcondition: The package's height has been returned
            get
            {
                return _height;
            }

            // Precondition: None
            // Postcondition: The package's height has been sest to the specified value
            set
            {
                if (value >= 0)
                    _height = value;
                else
                    throw new ArgumentOutOfRangeException("Height must be a positive number");
            }
        }

        public double Weight
        {
            // Precondition: None
            // Postcondition: The package's weight has been returned
            get
            {
                return _weight;
            }

            // Precondition: None
            // Postcondition: The package's weight has been set to the specified value
            set
            {
                if (value >= 0)
                    _weight = value;
                else
                    throw new ArgumentOutOfRangeException("Weight must be a positive number");
            }
        }
        // Precondition: None
        // Postcondition: A string with the package's information has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine;

            return $"Package\n{base.ToString()} {NL}" +
                   $"\nLength: {Length}  {NL}" + $"Width: {Width} " +
                   $" {NL}Height: {Height}" + $"{NL}Width: {Width}";

        }
    }
}
