using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode1
{
    class Program
    {
        // Program to solve Day 1 of the Advent of Code Challenge https://adventofcode.com/2019/day/1
        static void Main(string[] args)
        {
            try
            {
                // Load the input txt of masses of rocket modules
                Console.WriteLine("...Loading Rocket Modules...");
                IEnumerable<int> masses = readListInt();
                
                // Debug Output of masses
                printIEnumerableInt(masses);

                // Calculate Fuel requirement of each module, for part 2 use the full fuel cost
                Console.WriteLine("\n...Calculating Fuel Costs for Launch...");
                //IEnumerable<int> fuelCosts = masses.Select(x => calculateFuelCost(x));
                IEnumerable<int> fuelCosts = masses.Select(x => calculateFullFuelCost(x));

                // Debug Output of Fuel
                printIEnumerableInt(fuelCosts);

                // Calculate Fuel Cost
                Console.WriteLine("\n...Loading Fuel into Santa ONE...");
                int finalFuelCost = fuelCosts.Sum();

                Console.WriteLine(finalFuelCost);

                //We Have Reached the End
                Console.WriteLine("\n...All systems OK. Now Launching Santa ONE...");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
          
            
        }

        /// <summary>
        /// Load a IEnumerable of integers from a text file using a given input string.
        /// </summary>
        /// <param name="location">Location of the input file.</param>
        /// <returns>IEnumberable of integers from the text file.</returns>
        static IEnumerable<int> readListInt(string location = "input.txt")
        {           
            return File.ReadLines(location).Select(int.Parse);
        }

        /// <summary>
        /// DEBUG a IEnumberable of Integers for testing purposes.
        /// </summary>
        /// <param name="input">Values to output</param>
        static void printIEnumerableInt(IEnumerable<int> input)
        {
            Console.WriteLine(String.Join(", ", input));
        }

        /// <summary>
        /// Calculate how much fuel is required by providing the mass.
        /// Equations is Fuel Cost is equal to the mass divided by 3 and rounded down then subtract 2.
        /// f = (m / 3) - 2
        /// </summary>
        /// <param name="mass">Mass of the module</param>
        /// <returns>The fuel cost for the module.</returns>
        static int calculateFuelCost(int mass)
        {
            // C# Division operator rounds towards 0 with integers
            return (mass / 3) - 2;
        }

        /// <summary>
        /// Calculate the full fuel cost requirements by adding fuel to fuel the mass of the fuel.
        /// </summary>
        /// <param name="mass">Original Module mass</param>
        /// <returns>A full fuel calculation for the module and it's fuel requirements.</returns>
        static int calculateFullFuelCost(int mass)
        {
            int totalFuelCost = 0;
            // For as long as the mass is a positive non-zero value we will keep calculating the mass requirements for the fuel.
            while (mass > 0)
            {
                mass = (mass / 3) - 2;
                // Avoid adding a non positive integer value.
                if (mass > 0)
                    totalFuelCost += mass;
            }

            return totalFuelCost;
        }


        /// <summary>
        /// TODO Think about this a bit harder and finish it at some point.
        /// </summary>
        /// <param name="additionalMass"></param>
        /// <returns></returns>
        static int recursiveCalculateFuelCost(int additionalMass)
        {
            int totalMass = 0;
            // Calculate Cost of required Mass
            additionalMass = (additionalMass / 3) - 2;

            // If we finally reach a negative number we stop and return the value we have so far
            if (additionalMass > 0)
            {
                
                return totalMass + recursiveCalculateFuelCost(additionalMass);
            }
            
            return totalMass;
        }
    }
}
