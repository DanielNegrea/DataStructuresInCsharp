namespace DataStructuresInCsharp.StacksAndQueues
{
    /* Implementation of two stacks using one array */
    internal class TwoStacksOneArray
    {
        int size;
        int[] arr;
        int top1, top2; // Store top value indices of Stack 1 and Stack 2

        public TwoStacksOneArray(int n)
        {
            size = n;
            arr = new int[size];
            top1 = -1; // Top of Stack 1 starts from extreme left of array
            top2 = size; // Top of Stack 2 starts from extreme right of array

        }

        // Insert value in first Stack  
        public void PushOne(int value)
        {
            // Check for empty space and insert value if there's an empty space.
            if (top1 < top2 - 1)
            {
                arr[top1] = value;
                top1++;
            }
        }

        // Insert value in second Stack  
        public void PushTwo(int value)
        {
            // Check for empty space and insert value if there's an empty space.
            if (top1 < top2 - 1)
            {
                arr[top2] = value;
                top2--;
            }
        }

        // Return and remove top value from first Stack
        public int PopOne()
        {
            // Get value from top1 index and increment it.
            if (top1 >= 0)
            {
                int val = arr[top1];
                top1--;
                return val;
            }
            return -1;
        }

        // Return and remove top value from second Stack
        public int PopTwo()
        {
            // Get value from top2 index and increment it.
            if (top2 < size)
            {
                int val = arr[top2];
                top2++;
                return val;
            }
            return -1;
        }
    }
}