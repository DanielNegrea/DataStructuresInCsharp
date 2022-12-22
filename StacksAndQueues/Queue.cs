namespace DataStructuresInCsharp.StacksAndQueues
{
    /* Implementation of a Queue using LinkedList */
    internal class MyQueue
    {
        LinkedList<int> items = new LinkedList<int>(); // Using the frameworks doubly linked list
        int numElements;

        public MyQueue()
        {
            numElements = 0;
        }

        public bool IsEmpty()
        {
            return (numElements == 0);
        }

        public int GetFront()
        {
            LinkedListNode<int> headNode = items.First;

            if (headNode != null)
                return headNode.Value;
            else return -1;
        }

        public int GetTail()
        {
            LinkedListNode<int> lastNode = items.Last;

            if (lastNode != null)
                return lastNode.Value;
            else
                return -1;
        }

        public int GetSize()
        {
            return numElements;
        }

        public void Enqueue(int value)
        {
            LinkedListNode<int> node = new LinkedListNode<int>(value);
            numElements++;
            items.AddLast(node);
        }

        public void Dequeue()
        {
            numElements--;
            items.RemoveFirst();
        }

        /* Generate binary numbers from 1 to n using Queue -> Time complexity O(n) */
        public string[] GenerateBinaryNumbers(MyQueue myQueue, int n)
        {
            string[] result = new string[n];
            string s1, s2;

            myQueue.Enqueue(1); // Start with Enqueuing 1

            for (int i = 0; i < n; i++)
            {
                // To generate the binary number sequence, a number is dequeued from the queue and stored in the result array
                result[i] = myQueue.GetFront().ToString();
                myQueue.Dequeue();

                // 0 and 1 are appended to it to produce the next numbers, which are then also enqueued to the queue
                s1 = result[i] + "0";
                s2 = result[i] + "1";
                myQueue.Enqueue(Convert.ToInt32(s1));
                myQueue.Enqueue(Convert.ToInt32(s2));
            }

            return result;
        }

        /* Reversing first "k" elements of Queue -> Time complexity O(n) */
        public static MyQueue ReverseKElements(int k)
        {
            MyQueue queue = new MyQueue();
            int count = 1;

            // Populating queue
            while (queue.numElements < 10)
            {
                queue.Enqueue(count);
                count++;
            }
            count = 0;

            MyStack stack = new MyStack(k);

            // 1.Push first k elements in queue in a stack
            while (count < k)
            {
                stack.Push(queue.GetFront());
                queue.Dequeue();
                count++;
            }

            // 2.Pop Stack elements and enqueue them at the end of queue
            while (!stack.IsEmpty())
            {
                queue.Enqueue(stack.Pop());
            }

            int size = queue.GetSize();

            // 3.Dequeue queue elements till "k" and append them at the end of queue
            for (int i = 0; i < size - k; i++)
            {
                queue.Enqueue(queue.GetFront());
                queue.Dequeue();
            }

            return queue;
        }
    }
}