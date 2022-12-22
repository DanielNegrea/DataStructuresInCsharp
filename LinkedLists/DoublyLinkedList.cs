namespace DataStructuresInCsharp.LinkedLists
{
    internal class DoublyLinkedList
    {
        public class Node
        {
            public int data; // Data to store (could be int,string,object etc)
            public Node nextElement; // Pointer to next element
            public Node prevElement; // Pointer to previous element

            public Node(int data)
            {
                // Constructor to initialize nextElement of newly created Node
                this.data = data;
                nextElement = null;
            }
        };

        Node head;
        Node last;
        int length;

        public DoublyLinkedList()
        {
            this.head = null;
            this.last = null;
            this.length = 0;
        }

        public bool IsEmpty()
        {
            if (this.head == null) // Check whether the head points to null
                return true;
            else
                return false;
        }

        public int GetHead()
        {
            if (!(this.head == null))
                return this.head.data;
            else
                return -1;
        }

        public int GetLast()
        {
            if (!(this.last == null))
                return this.last.data;
            else
                return -1;
        }

        public int InsertTail(int value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                last = newNode;
            }
            else
            {
                newNode.prevElement = last;
                last.nextElement = newNode;
                last = newNode;
            }
            length++;
            return newNode.data;
        }

        public bool DeleteHead()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty");
                return false;
            }
            head = head.nextElement;

            length--;
            return true;
        }

        public bool PrintList()
        {
            if (IsEmpty())
            {
                Console.Write("List is Empty!");
                return false;
            }
            Node temp = head;
            Console.Write("List : ");

            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.nextElement;
            }
            Console.WriteLine("null ");
            return true;
        }
    }
}