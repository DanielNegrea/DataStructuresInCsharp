using DataStructuresInCsharp.LinkedLists;

namespace DataStructuresInCsharp.Arrays
{
    internal class HelperMethods
    {
        public static void QuickSort(int[] myArray, int low, int high)
        {
            int pivotLocation = 0;

            if (low < high)
            {
                pivotLocation = Partition(myArray, low, high);
                QuickSort(myArray, low, pivotLocation - 1);
                QuickSort(myArray, pivotLocation + 1, high);
            }
        }

        private static int Partition(int[] myArray, int low, int high)
        {
            int pivot = myArray[high];
            int i = low - 1; // index of smaller element

            for (int j = low; j < high; j++)
            {
                if (myArray[j] <= pivot) // If current element is <= to pivot
                {
                    i++;
                    Swap(myArray, i, j); // swap arr[i] and arr[j]
                }
            }
            Swap(myArray, i + 1, high); // swap arr[i+1] and arr[high] (or pivot)

            return i + 1;
        }

        private static void Swap(int[] myArray, int a, int b)
        {
            int temp = myArray[a];
            myArray[a] = myArray[b];
            myArray[b] = temp;
        }

        private SinglyLinkedList RandomNumberGenerator(SinglyLinkedList listA)
        {
            var random = new Random(); // Random numbers generator
            int num = 0;

            for (int i = 0; i < 6; i++)
            {
                num = random.Next(10); // Generating random numbers in range 1 to 10
                listA.InsertAtTail(num);
            }

            return listA;
        }
    }
}