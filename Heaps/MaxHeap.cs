namespace DataStructuresInCsharp.Heaps
{
    internal class MaxHeap<T> where T : IComparable<T>
    {
        List<T> heap = null;

        public MaxHeap()
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
                MaxHeapify(i);
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

        /* This function returns the maximum value from the heap, which is the root, i.e., the first value in the list -> Time complexity O(1) */
        public T GetMax()
        {
            if (Size() <= 0)
            {
                return (T)Convert.ChangeType(-1, typeof(T));
            }
            else
                return heap[0];
        }

        /* This function removes the maximum value from the heap -> Time complexity O(log(n)) */
        public void RemoveMax()
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

                MaxHeapify(0); // Restore heap property
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
            else if (heap[Parent(i)].CompareTo(heap[i]) < 0)
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
        public void MaxHeapify(int i)
        {
            int lc = LeftChild(i);
            int rc = RightChild(i);
            int imax = i;

            if (lc < Size() && (heap[lc].CompareTo(heap[imax]) > 0))
                imax = lc;
            if (rc < Size() && (heap[rc].CompareTo(heap[imax]) > 0))
                imax = rc;
            if (i != imax)
            {
                T temp = heap[i];
                heap[i] = heap[imax];
                heap[imax] = temp;
                MaxHeapify(imax);
            }
        }

        /* Find "K" largest elements in the array -> Time complexity O(n + klogn) */
        public void FindKLargest(MaxHeap<int> maxHeap, int[] arr, int k)
        {
            List<int> output = new List<int>();

            for (int i = 0; (i < k) && (i < arr.Length); i++)
            {
                output.Add(maxHeap.GetMax());
                maxHeap.RemoveMax();
            }

            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }
        }
    }
}