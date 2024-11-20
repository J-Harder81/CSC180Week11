
/*
 * CSC180 Week 11 Programmming Assignment - Problem #2
/* useful links:
 * https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
 * https://dotnetcoretutorials.com/2020/05/10/basic-sorting-algorithms-in-c/
 * https://medium.com/engineering-hub/https-medium-com-engineering-hub-sorting-algorithms-in-csharp-and-java-4615f6f87696
 */

using System;
using System.IO;
using System.Diagnostics;

namespace CSC180Week11
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt"; //#4. The numbers.txt file can be found in C:\Users\Justi\source\repos\CSC180Week11\bin\Debug
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);
            string[] lines = File.ReadAllLines(fileName); //Reads all lines in a file into a string array lines
            int[] values = new int[lines.Length]; //Creates an integer array values the same size as the number of lines in the file
            for (int i = 0; i < values.Length; i++) //Generates a loop to iterate through the array
            {
                values[i] = Convert.ToInt32(lines[i]); //Converts each string lines to an integer and stores the integer in the values array
            }
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        //This method generates a number of random integers within a specified range and
        //writes them to a file line by line
        {
            using (var writer = new StreamWriter(fileName)) //Opens a StreamWriter to write to the specified file
            {
                Random r = new Random(); //Creates a random number generator
                int number = 0; //Initializes the integer number to 0
                {
                    for (int i = 1; i < total; i++) //Generates a loop for the specified total of integers
                    {
                        number = r.Next(lowerRange, upperRange); //Generates a random number in the specified range
                        writer.WriteLine(number); //Writes the number to a line in the file
                    }
                }
            }
        }

        static void Method02(int[] arr)
        //This method sorts an array of integers from smallest to largest
        {
            for (int start = 0; start < arr.Length - 1; start++) //Generates a loop over the array to sort it
            {
                int posMin = start; //Assumes that the first unsorted integer is the smallest
                for (int i = start + 1; i < arr.Length; i++) //Loops to find the smallest integer in the array
                {
                    if (arr[i] < arr[posMin]) //If statement for when a smaller integer in the array is found
                    {
                        posMin = i; //Updates the position of the smallest integer
                    }
                }
                //Swap the smallest integer with the first unsorted integer in the array
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}