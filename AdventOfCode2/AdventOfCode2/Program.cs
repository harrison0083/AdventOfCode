using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> opCodes = readListString();
                Console.WriteLine("...Printing Loaded OpCodes...");
                printListInt(opCodes);

                Console.WriteLine("...Running Program...");

                for (int ptr = 0; ptr < opCodes.Count; ptr = ptr+4)
                {
                    int opCodeLocation = ptr; // Use this as a pointer to our currently executed opCode
                    Operations operation = (Operations)opCodes[opCodeLocation]; // Get the operation from the new opCode

                    // If the operation is halt then exit loop.
                    if (operation == Operations.Halt)
                        break;

                    if (operation == Operations.Add || operation == Operations.Multiply)
                    {
                        int inputOneLocation = opCodes[ptr + 1];
                        int inputTwoLocation = opCodes[ptr + 2];
                        int outputLocation = opCodes[ptr + 3];

                        // We perform our operation on the values given at the location
                        if (operation == Operations.Add)
                            opCodes[outputLocation] = opCodes[inputOneLocation] + opCodes[inputTwoLocation];

                        if (operation == Operations.Multiply)
                            opCodes[outputLocation] = opCodes[inputOneLocation] * opCodes[inputTwoLocation];
                    }

                }

                Console.WriteLine("...Outputing new Program...");
                printListInt(opCodes);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

        }

        enum Operations
        {
            Add = 1,
            Multiply = 2,
            Halt = 99
        }

        static int getOpCodeParameters(Operations operation)
        {
            int numberOfParameters = 0;

            if (operation == Operations.Add || operation == Operations.Multiply)
                numberOfParameters = 3;

            return numberOfParameters;
        }

        /// <summary>
        /// Load a array of strings from a text file using a given input string.
        /// Splits the 
        /// </summary>
        /// <param name="location">Location of the input file.</param>
        /// <param name="splitChar">Character used to split apart the input.</param>
        /// <returns>array of strings from the text file.</returns>
        static List<int> readListString(string location = "input.txt", char splitChar = ',')
        {
            string[] values = File.ReadAllText(location).Split(splitChar);
            List<int> numbers = new List<int>();
            foreach (string s in values)
            {
               numbers.Add(int.Parse(s));
            }
            return numbers;
        }

        /// <summary>
        /// DEBUG a IEnumberable of Integers for testing purposes.
        /// </summary>
        /// <param name="input">Values to output</param>
        static void printListInt(List<int> input)
        {
            Console.WriteLine(String.Join(", ", input));
        }

    }
}
