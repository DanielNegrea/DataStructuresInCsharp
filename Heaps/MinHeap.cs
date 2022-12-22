namespace DataStructuresInCsharp.Heaps
{
    internal class MinHeap<T> where T : IComparable<T>
    {
        List<T> heap = null;

        public MinHeap()
        {
            heap = new List<T>();
        }

        /* Time complexity O(n) */
        public void BuildHeap(T[] arr, int size)
        {
            // Copy elements of array into the List heap
            heap.AddRange(arr);
            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                MinHeapify(i);
            }
        }

        public int Size()
        {
            return heap.Count;
        }

        public int Parent(int i)
        {
            return (i - 1) / 2;
        }
        public int LeftChild(int i)
        {
            return i * 2 + 1;
        }
        public int RightChild(int i)
        {
            return i * 2 + 2;
        }

        public void PrintHeap()
        {
            for (int i = 0; i <= Size() - 1; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine("");
        }

        /* This function returns the minimum value from the heap, which is the root, i.e., the first value in the list -> Time complexity O(1) */
        public T GetMin()
        {
            if (Size() <= 0)
            {
                return (T)Convert.ChangeType(-1, typeof(T));
            }
            else
                return heap[0];
        }

        /* This function removes the maximum value from the heap -> Time complexity O(log(n)) */
        public void RemoveMin()
        {
            if (Size() == 1)
            {
                // Remove the last item from the list
                heap.RemoveAt(heap.Count - 1);
            }
            else if (Size() > 1)
            {
                // Swaps the value of two variables
                T temp = heap[0];
                heap[0] = heap[Size() - 1];
                heap[Size() - 1] = temp;

                heap.RemoveAt(heap.Count - 1); // Deletes the last element

                MinHeapify(0); // Restore heap property
            }
        }

        /* This function appends the given value to the heap list and calls the PercolateUp() function on it.
         * * It will keep on swapping the values of nodes until the heap property is restored -> Time complexity O(log(n)) */
        public void Insert(T key)
        {
            // Push elements into vector from the back
            heap.Add(key);

            // Store index of last value of vector in variable i
            int i = Size() - 1;

            // Restore heap property
            PercolateUp(i);
        }

        /* This function restores the heap property by swapping the value at a parent node if it is less than the value at a child node.
         * After swapping, the function is called recursively on each parent node until the root is reached. -> Time complexity O(log(n)) */
        public void PercolateUp(int i)
        {
            if (i <= 0)
                return;
            else if (heap[Parent(i)].CompareTo(heap[i]) > 0)
            {
                // Swaps the value of two variables
                T temp = heap[i];
                heap[i] = heap[Parent(i)];
                heap[Parent(i)] = temp;
                PercolateUp(Parent(i));
            }
        }

        /* This function restores the heap property after a node is removed. It restores the heap property by starting from a given node and continuing down to the leaves.
         * It swaps the values of the parent nodes with the values of their largest child nodes until the heap property is restored. -> Time complexity O(log(n)) */
        public void MinHeapify(int i)
        {
            int lc = LeftChild(i);
            int rc = RightChild(i);
            int imin = i;

            if (lc < Size() && (heap[lc].CompareTo(heap[imin]) < 0))
                imin = lc;
            if (rc < Size() && (heap[rc].CompareTo(heap[imin]) < 0))
                imin = rc;
            if (i != imin)
            {
                T temp = heap[i];
                heap[i] = heap[imin];
                heap[imin] = temp;
                MinHeapify(imin);
            }
        }

        /* Time complexity O(n) */
        public string ConvertMaxHeapToMin(List<int> maxHeap)
        {
            string result = "";

            maxHeap = BuildMinHeap(maxHeap);
            for (int i = 0; i < maxHeap.Count; i++)
            {
                if (i == maxHeap.Count - 1)
                    result += maxHeap[i].ToString();
                else
                    result += maxHeap[i].ToString() + ",";
            }

            return result;
        }

        /* Find "K" smallest elements in the array -> Time complexity O(n + klogn) */
        public void FindKSmallest(MinHeap<int> minHeap, int[] arr, int k)
        {
            List<int> output = new List<int>();

            for (int i = 0; (i < k) && (i < arr.Length); i++)
            {
                output.Add(minHeap.GetMin());
                minHeap.RemoveMin();
            }

            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }
        }

        private static List<int> BuildMinHeap(List<int> heapList)
        {
            for (int i = (heapList.Count - 1) / 2; i > -1; i--)
            {
                MinHeapify(heapList, i);
            }
            return heapList;
        }

        private static void MinHeapify(List<int> heapList, int i)
        {
            int lc = i * 2 + 1;
            int rc = i * 2 + 2;
            int imin = i;

            if (lc < heapList.Count && (heapList[lc].CompareTo(heapList[imin]) < 0))
                imin = lc;
            if (rc < heapList.Count && (heapList[rc].CompareTo(heapList[imin]) < 0))
                imin = rc;
            if (i != imin)
            {
                int temp = heapList[i];
                heapList[i] = heapList[imin];
                heapList[imin] = temp;
                MinHeapify(heapList, imin);
            }
        }
    }
}