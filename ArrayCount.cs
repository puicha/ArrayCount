using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCount
{
    class ArrayCount
    {
        static void Main()
        {
            // Declare variables
            string inputString = "";        // Initialized to null
            int index = 0;                  // Initialized to 0
            int invalidCount = 0;           // Initialized to 0
            int validCount = 0;             // Initialized to 0
            int count = 0;                  // Initialized to 0    
            int[] numArray = new int[100];  // Create an array that can hold 100 elements, in this case each element holds the value entered by the user
  
            // Accept user entry
            Console.Write("Enter number (Enter -99 to exit): ");
            inputString = Console.ReadLine();

            // Use sentinel controlled while-loop to determine when the user wants to finish entering number
            while (inputString != "-99")
            {
                // Validate user input and count invalid numbers
                if (int.TryParse(inputString, out numArray[index]) == false)
                {
                    Console.WriteLine("Please enter numeric value");  // Display a message
                    invalidCount++;   
                    // If the user entered non-numeric value, place value of -1 for that element
                    numArray[index] = -1;
                        
                }
                else if (numArray[index] < 0 || numArray[index] > 10)
                {
                    Console.WriteLine("Valid values are from 0 to 10");  // Display a message
                    invalidCount++;
                    // If the user entered number < 0 or > 10, place value of -1 for that element
                    numArray[index] = -1;
                }
                else
                {
                    // Count valid number
                    validCount++;
                }
                    
                // Increment index counter as values are entered, continue entering number or enter -99 to exit
                index++;              
                Console.Write("Enter number (Enter -99 to exit): ");
                inputString = Console.ReadLine();              
            }

            /* To distinguish value of 0 the user entered from value of 0 for empty elements, assign value of -1 to empty elements in array after 
               the user finished entering number */
            for (int j = index; j < numArray.Length; j++)
            {
                numArray[j] = -1;
            }
            
            // Display number of valid value 
            Console.WriteLine("\nValid value were inputted {0} times", validCount);

            // Display number of invalid value 
            Console.WriteLine("\nInvalid value were inputted {0} times", invalidCount);

            // Display numbers in array using foreach loop           
            Console.WriteLine("\nNumber entered are:\n ");
            foreach (int value in numArray)
            {
                if (value > -1)
                {
                    Console.Write("{0}\t", value);
                }
            }

            /* To output a list of distinct valid entries and a count of how many times that entry occurred,
               One method that can be used is to sort the elements in array and use nested loops as well as if-else statements to count how many 
               duplicate for each entry */
            Console.WriteLine("\n\nTo count duplicate number, sort numbers\n");
            Array.Sort(numArray);

            // Display sorted numbers in array using foreach loop          
            Console.WriteLine("Numbers are sorted as followed\n");
            foreach (int value in numArray)
            {
                if (value > -1)
                {
                    Console.Write("{0}\t", value);
                }
            }

            // Use for loop to go through each element in array to find duplicate
            for (int i = 0; i < numArray.Length; i++)
            {
                // Use if statement to check if elements are greater than -1 to ensure the program will use only value entered from the user
                if (numArray[i] > -1)
                {
                    // Use foreach loop to compare each element in array and the value at element i of the for loop
                    foreach (int value in numArray)
                    {
                        // If value equals to value at element i, count value
                        if (value == numArray[i])
                        {
                            count++;                          
                        }                        
                    }
                    /* Use if-else statement to display value of each element and the number that value occurred
                       If value of element equals to value of previous element, skip displaying that element and reset count number to 0 and continue
                       to the next element.
                       If not, display value of that element and the number that value occurred, reset count number to 0 and 
                       continue to the next element */
                    if (numArray[i] == numArray[i - 1])
                    {               
                        count = 0;
                    }
                    else
                    {
                        Console.WriteLine("\n\n{0} was entered {1} times", numArray[i], count);
                        count = 0;
                    }     
                }          
            }
            Console.ReadKey();           
        }
    }
}
