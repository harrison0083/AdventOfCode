using System;
using System.Collections.Generic;

namespace AdventOfCode4
{
    class Program
    {
        static void Main(string[] args)
        {
            // These are the limits for the 6 digit number
            int lowerBound = 183564;
            int upperBound = 657474;
            Console.WriteLine(lowerBound);
            Console.WriteLine(upperBound);

            List<int> validPasswords = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                // Reset validity.
                bool isSixDigits = true;
                bool containsDoubleDigits = false;
                bool onlyIncreasesValue = true;
                // Check number is 6 digits
                if (i.ToString().Length != 6)
                    isSixDigits = false;
                
                string currentCode = i.ToString();
                char previousC = ' ';
                int consecutiveCharCount = 1;
                foreach (char c in currentCode)
                {
                    // Check That There is a sit of double adjacent digits, eg 11, 44, 55 so forth.
                    if (char.IsLetterOrDigit(previousC))
                        if (c.Equals(previousC))
                        {
                            consecutiveCharCount++;
                        }
                        else
                        {
                            if (consecutiveCharCount == 2)
                                containsDoubleDigits = true;
                            consecutiveCharCount = 1;
                        }
                    // Part 1 Version
                    //if (c.Equals(previousC))
                    //    containsDoubleDigits = true;

                    // Check that from left to right the number only increases.
                    // If the previous digit is greater than the current one then we know this is false.
                    if (char.IsDigit(previousC) && char.IsDigit(c))
                        if (c < previousC)
                            onlyIncreasesValue = false;

                    // Record the current c value for the next loop.
                    previousC = c;
                }
                

                // If we hit all the criteria add this number to our collection.
                if (isSixDigits && containsDoubleDigits && onlyIncreasesValue)
                    validPasswords.Add(i);

            }

            // How many valid passwords are there?
            Console.WriteLine("There are {0} valid passwords", validPasswords.Count);

        }
    }
}
