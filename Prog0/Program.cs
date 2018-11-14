/** Program 1B
    CIS 200-01
    Due: 10/4/17
    Grading ID: C6643
    This program adds differnt parcels to a list and displays their information. This program also uses LINQ queries to query the list
    and outputs parcel objects specified by the LINQ query.**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1B
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", 
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", 
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", 
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Mary Sue", "123 Muffin Man Lane",
                "Detroit", "MI", 48127); // Test Address 5
            Address a6 = new Address("Donald Trump", "725 5th Avenue", 
                "New York", "NY", 10022); // Test Address 6
            Address a7 = new Address("Logan Payton", "123 Bellamy Circle", "Apt 204", 
                "Louisville", "KY", 40208); // Test Address 7
            Address a8 = new Address("Donna Noble", "9876 Doctor Lane",
                "Cardiff", "NY", 13084); // Test Address 8


            // letter objects
            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test Letter 3
            Letter l4 = new Letter(a5, a7, 1.60m); // Test Letter 4

            // groundpackage objects
            GroundPackage gp1 = new GroundPackage(a1, a4, 20, 20, 20, 50); // Test GroundPackage 1
            GroundPackage gp2 = new GroundPackage(a2, a4, 10, 10, 05, 10); // Test GroundPackage 2
            GroundPackage gp3 = new GroundPackage(a5, a8, 20, 50, 100, 90.5);// Test GroundPackage 3
            GroundPackage gp4 = new GroundPackage(a1, a6, 5, 5, 5, 2.5);    // Test GroundPackage 4

            // NextDayAirPackage objects
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a4, 20, 20, 80, 100, 3.50m); // Test NextDayAirPackage 1
            NextDayAirPackage ndap2 = new NextDayAirPackage(a2, a3, 50, 50, 20, 20, 10.50m); // Test NextDayAirPackage 2
            NextDayAirPackage ndap3 = new NextDayAirPackage(a3, a6, 10, 20, 30, 40, 15.5m);  // Test NextDayAirPackage 3
            NextDayAirPackage ndap4 = new NextDayAirPackage(a5, a7, 5, 5, 5, 10, 1.5m);      // Test NextDayAirpackage 4

            // TwoDayAirPackage objects
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a1, a4, 50, 20, 50, 150, TwoDayAirPackage.Delivery.Early); // Test TwoDayAirPackage 1
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a3, 20, 20, 20, 75, TwoDayAirPackage.Delivery.Saver);  // Test TwoDayAirPackage 2

            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            // Add test data to list
            parcels.Add(l1);
            parcels.Add(l2);
            parcels.Add(l3);
            parcels.Add(l4);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(gp4);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);        
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            // Display data
            Console.WriteLine("Program 1B - List of Parcels\n");

            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }

            // LINQ query that sorts parcels by destination Zip Code
            var destinationZipSorted =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            Console.WriteLine("\n\n\nParcels sorted by destination zip:");
            Console.WriteLine("--------------------");

            foreach (var p in destinationZipSorted)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\n\n\nParcels sorted by cost:");
            Console.WriteLine("--------------------");

            // LINQ query that sorts parcels by cost
            var sortedByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;

            foreach (var p in sortedByCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\n\n\nParcels sorted by parcel type and cost:");
            Console.WriteLine("--------------------");

            // LINQ query that sorts by Parcel type and then by cost
            var sortedByParcelAndCost =
                from p in parcels
                let parcelType = p.GetType().ToString()
                orderby parcelType, p.CalcCost() descending
                select p;

            foreach (var p in sortedByParcelAndCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\n\n\nParcels sorted by weight:");
            Console.WriteLine("--------------------");

            // Airpackages that are heavy are sorted by weight
            var sortedByWeight =
                from p in parcels
                where p is AirPackage
                let package = p as AirPackage
                where package.IsHeavy()
                orderby package.Weight descending
                select package;


            foreach (var p in sortedByWeight)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------");
            }
    
                

        }
    }
}
