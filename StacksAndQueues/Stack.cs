using System.Diagnostics;

namespace DataStructuresInCsharp.StacksAndQueues
{
    /* Implementation of a Stack using Array */
    internal class MyStack
    {
        int[] stackArr;
        int capacity;
        int numElements;

        public MyStack(int size)
        {
            stackArr = new int[size];
            capacity = size;
            Debug.Assert(stackArr != null);
            numElements = 0;
        }

        public bool IsEmpty()
        {
            return (numElements == 0);
        }

        public int GetTop()
        {
            return (numElements == 0 ? -1 : stackArr[numElements - 1]);
        }

        public bool Push(int value)
        {
            if (numElements < capacity)
            {
                stackArr[numElements] = value;
                numElements++;
                return true;
            }
            else
            {
                Console.WriteLine("Stack Full.");
                return false;
            }
        }

        public int Pop()
        {
            if (numElements == 0)
            {
                Console.WriteLine("Stack Empty");
                return -1;
            }
            else
            {
                numElements--;
                return stackArr[numElements];
            }
        }

        public int GetSize()
        {
            return numElements;
        }

        public void ShowStack()
        {
            int i = 0;
            while (i < numElements)
            {
                Console.Write("\t" + stackArr[numElements - 1 - i]);
                i++;
            }
            Console.WriteLine("");
        }

        /* Sort stack elements in ascending order -> Time complexity O(n2) */
        public void SortStack(MyStack myStack)
        {
            myStack.Push(2);
            myStack.Push(97);
            myStack.Push(4);
            myStack.Push(42);
            myStack.Push(12);
            myStack.Push(60);
            myStack.Push(23);

            int[] arr = new int[myStack.numElements];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = myStack.Pop();
            }

            Array.Sort(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                myStack.Push(arr[i]);
            }

            myStack.ShowStack();
        }

        /* Compute "postfix" mathematical expressions using Stacks, where the operators appear after the two operands involved in the expression */
        /* -> Time complexity O(n) */
        public static void EvaluatePostFixExpression(Stack<int> stack)
        {
            string expression = "921*-8-4+";
            char character;

            // Scan expression character by character
            for (int i = 0; i < expression.Length; i++)
            {
                int first, second;
                character = expression[i];

                // If character is operator then pop two elements from stack and perform the operation and put the result back in stack
                if (!Char.IsDigit(character))
                {
                    first = stack.Pop();
                    second = stack.Pop();

                    switch (character)
                    {
                        case '+':
                            stack.Push(second + first);
                            break;
                        case '-':
                            stack.Push(second - first);
                            break;
                        case '*':
                            stack.Push(second * first);
                            break;
                        case '/':
                            stack.Push(second / first);
                            break;
                    }
                }
                // If character is a number push it in stack
                else
                    stack.Push(character - '0');
            }
            Console.WriteLine(stack.Peek()); // At the end, Stack will contain result of whole expression.
        }

        /* Implement a function to find the next greater element after any given element in an array -> Time complexity O(n) */
        /* To keep it simple, the next greater element for the last or maximum value in the array is -1 */
        public static void NextGreaterElement()
        {
            int[] myArr = new int[] { 4, 6, 3, 2, 8, 1 };
            int[] result = new int[myArr.Length];
            int next, top;

            Stack<int> stack = new Stack<int>();

            // Iterate the array from the last element to the first one, because at every index, you will have access to the next greater element in the array,
            // which will be present in the stack
            for (int i = myArr.Length - 1; i >= 0; i--)
            {
                next = myArr[i]; // Potential next greater element

                if (stack.Count > 0)
                    top = stack.Peek();
                else
                    top = -1;

                // Pop from the stack until you get the greater element on top of the stack
                while (stack.Count != 0 && top <= next)
                {
                    stack.Pop();
                    if (stack.Count > 0)
                        top = stack.Peek();
                    else
                        top = -1;
                }

                if (stack.Count != 0)
                    result[i] = stack.Peek();
                else
                    result[i] = -1;

                stack.Push(next); // For next iteration
            }

            Console.WriteLine(result);
        }

        /* For all the parentheses to be balanced, every opening parenthesis must have a closing one. -> Time complexity O(n) */
        /* The order in which they appear also matters. For example, {[]} is balanced, but {[}] is not */
        public static bool IsBalanced()
        {
            string expression = "{[({})]}";

            // If expression length is uneven, clearly the string can't be balanced
            if (expression.Length % 2 != 0)
                return false;

            Stack<char> stack = new Stack<char>();
            char character;

            for (int i = 0; i < expression.Length; i++)
            {
                character = expression[i];
                // Whenever you find a closing parenthesis, you can deduce that the string is unbalanced based on two conditions
                if (character == '}' || character == ')' || character == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    if ((character == '}' && stack.Pop() != '{') || (character == ')' && stack.Pop() != '(') || (character == ']' && stack.Pop() != '['))
                        return false;
                }
                else
                    stack.Push(character); // For each opening parentheses, push it into stack

            }
            if (stack.Count != 0)
                return false;

            // If all the parentheses are balanced, the stack should be empty by the end because you pop every opening parenthesis once its closing parenthesis is found
            return true;
        }
    }
}