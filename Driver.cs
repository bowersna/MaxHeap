using System;
using System.Diagnostics;
// ------------------------------------------------ Driver.cs --------------------------------------------------------
//
// 	Programmer’s Name:	Nicholas Bowers							Course-Section: CSCI 3230 Algorithms
//	Creation Date:	3/6/14		                                Date of Last Modification:	3/24/14	
//  e-mail address: BOWERSNA@goldmail.etsu.edu
//
// --------------------------------------------------------------------------------------------------------------------
//
//	Purpose - driver to insert values into the MaxHeap, then sort the MaxHeap and display the contents to the user
//
// --------------------------------------------------------------------------------------------------------------------
namespace HeapLab
{
    class Driver
    {
        public static void Main(String[] args)
        {
            int numStrings, Num;
            string input, numS;

            //prompt for the number of values being placed into the MaxHeap
            Console.Write("Number of values in the Heap: ");
            numS = Console.ReadLine();
            numStrings = Convert.ToInt32(numS);

            MaxHeap heap = new MaxHeap(numStrings);
            //prompt user to enter strings one at a time
            //insert each string one at a time into heap
            Console.WriteLine("\n\nEnter values one at a time: ");
            do
            {
                input = Console.ReadLine();
                Num = Convert.ToInt32(input);
                heap.Insert(Num);
                numStrings--;
            }
            while (numStrings > 0);

            //Display the MaxHeap before sorting
            Console.WriteLine("\n\nExtract-Max to sort Heap..\n");
            Console.WriteLine("Before sort: ");
            heap.Print();
            Console.WriteLine("\n");

            //time how long it takes to sort the MaxHeap
            //use Print_Array to display after extracting due to loss of size variable
            Stopwatch sw = Stopwatch.StartNew();
            heap.HeapSort();
            sw.Stop();

            //print the contents of the MaxHeap after sorting using Extract-Max
            Console.WriteLine("After sort: ");
            heap.Print_Array();

            //display the time it took to sort the maxHeap
            Console.WriteLine("\nTime it took to sort using Extract-Max: {0}", sw.Elapsed.TotalMilliseconds / 1000);

            //pause for display
            Console.ReadLine();
        }
    }
}
