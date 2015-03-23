using System;
// ------------------------------------------------ MaxHeap.cs --------------------------------------------------------
//
// 	Programmer’s Name:	Nicholas Bowers							Course-Section: CSCI 3230 Algorithms
//	Creation Date:	3/6/14		                                Date of Last Modification:	3/24/14	
//  e-mail address: BOWERSNA@goldmail.etsu.edu
//
// --------------------------------------------------------------------------------------------------------------------
//
//	Purpose - manage a Max Heap using an array of string values
//
// --------------------------------------------------------------------------------------------------------------------
namespace HeapLab
{
    class MaxHeap
    {
        private int max_size;   //maximum size the heap can be
        private int size;       //current size of heap
        private int[] h;     //array of strings the heap will use

        /// <summary>
        /// Constructor for Max Heap
        /// </summary>
        /// <param name="heapSize">Max Size the heap can be</param>
        public MaxHeap(int heapSize)
        {
            size = 0;
            max_size = heapSize + 1;
            h = new int[max_size];
        }

        /// <summary>
        /// Print method used after sorting of array has been done, since size
        /// of MaxHeap will be 0, we use the (max_size variable - 1) in this loop
        /// </summary>
        public void Print_Array()
        {
            for (int i = 1; i <= (max_size - 1); i++)
                Console.Write(h[i] + " ");

            Console.WriteLine();
        }

        /// <summary>
        /// Print the contents of the Max Heap before sorting
        /// </summary>
        public void Print()
        {
            for (int i = 1; i <= size; i++)
                Console.Write(h[i] + " ");

            Console.WriteLine();
        }

        /// <summary>
        /// Insert an item into the Max Heap, swap if child > parent
        /// </summary>
        /// <param name="item">String to be inserted</param>
        public void Insert(int item)
        {
            //increment size
            size++;
            //insert item
            h[size] = item;

            //check to see if we need to swap values
            //if the child is greater than the parent...
            int index = size;
            while (index != 1)
            {
                if ((h[index].CompareTo(h[Parent(index)])) == 1)
                {
                    Swap(index, Parent(index));
                }
                index--;
            }
            //print after every swap
            Print();
        }

        /// <summary>
        /// Find the parent index 
        /// </summary>
        /// <param name="index">Current index in Max Heap</param>
        /// <returns></returns>
        public int Parent(int index)
        {
            return index / 2;
        }

        /// <summary>
        /// Swap child and parent strings in the Max Heap
        /// </summary>
        /// <param name="parent">parent index</param>
        /// <param name="child">child index</param>
        public void Swap(int parent, int child)
        {
            //exchange the parent with the child
            int temp = h[parent];
            h[parent] = h[child];
            h[child] = temp;
        }

        /// <summary>
        /// Swaps the last item with the root of the heap, then balances
        /// the Max Heap, size is decreased by 1 each call to the method
        /// </summary>
        public void ExtractMax()
        {
            int max = h[1];
            h[1] = h[size];
            h[size] = max;
            size--;

            MaxHeapify(1);
        }

        /// <summary>
        /// Balances the tree from the index, usually the root of the Heap
        /// </summary>
        /// <param name="index"></param>
        public void MaxHeapify(int index)
        {
            int max = index;
            //get the left and right child index using parent index
            int left = 2 * index;
            int right = left + 1;

            //if the left child is less than size and greater than the max value
            //we want to swap the parent with the left value
            if (left < size && h[left] > h[max])
            {
                max = left;
            }
            //if the right child is less than size and greater then the max value
            //we want to swap the parent with the right value
            if (right < size && h[right] > h[max])
            {
                max = right;
            }
            //if the max value is not the parent value
            //we swap the parent with the max value index found
            //then we balance the Max Heap with MaxHeapify method
            if (max != index)
            {
                Swap(index, max);
                MaxHeapify(max);
            }
        }

        /// <summary>
        /// Sorts the MaxHeap by calling the ExtractMax method until the size is 0
        /// </summary>
        public void HeapSort()
        {
            while (size != 0)
            {
                ExtractMax();
            }
        }
    }
}
