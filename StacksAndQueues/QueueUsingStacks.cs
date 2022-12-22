namespace DataStructuresInCsharp.StacksAndQueues
{
    /* Implementation of a Queue using Stacks */
    internal class QueueUsingStacks
    {
        // Using the framework Stack built-in data structure
        Stack<int> mainStack; // Store queue elements
        Stack<int> tempStack; // Acts as a temporary buffer to provide queue functionality

        public QueueUsingStacks()
        {
            mainStack = new Stack<int>();
            tempStack = new Stack<int>();
        }

        public void Enqueue(int value)
        {
            // Before insertion, all the other elements are transferred to tempStack and naturally, their order is reversed
            while (mainStack.Count != 0)
            {
                tempStack.Push(mainStack.Pop());
            }
            // Newly inserted value is at the bottom of the main stack
            mainStack.Push(value);

            // Finally, all the elements are pushed back into mainStack and tempStack becomes empty
            while (tempStack.Count != 0)
            {
                mainStack.Push(tempStack.Pop());
            }
        }

        public int Dequeue()
        {
            if (mainStack.Count == 0)
                return -1;
            else
                return mainStack.Pop(); // Return top element of mainStack as we always put oldest entered element at the top of mainStack
        }
    }
}