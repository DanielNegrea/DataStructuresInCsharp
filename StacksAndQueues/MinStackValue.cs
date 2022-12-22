namespace DataStructuresInCsharp.StacksAndQueues
{
    /* Implement a solution where the minimum value of the stack is returned in O(1) time. The element is not popped from the stack. Its value is simply returned. */
    internal class MinStackValue
    {
        Stack<int> mainStack;
        Stack<int> minStack;

        // We will use two stacks, mainStack to hold origional values and minStack to hold minimum values. Top of minStack will always be the minimum value from mainStack
        public MinStackValue(int size)
        {
            mainStack = new Stack<int>(size);
            minStack = new Stack<int>(size);
        }

        internal int Pop()
        {
            minStack.Pop(); // Pop element from minStack to make it sync with mainStack
            return mainStack.Pop(); // Pop element from mainStack and return that value
        }

        // Push value in mainStack and check value with the top value of minStack. If value is greater than top, then push top in minStack, else push value in minStack
        internal void Push(int value)
        {
            mainStack.Push(value);

            if ((minStack.Count != 0) && (value > minStack.Peek()))
            {
                minStack.Push(minStack.Peek());
            }
            else
                minStack.Push(value);
        }

        // Returns minimum value from MinStackValue class in O(1) Time
        internal int Min()
        {
            return minStack.Peek();
        }
    }
}