namespace DataStructuresInCsharp.LinkedLists
{
    public class SinglyLinkedList
    {
        public class Node
        {
            internal int data; // Data to store (could be int,string,object etc)
            internal Node? nextElement; // Pointer to next element

            public Node()
            {
                // Constructor to initialize nextElement of newly created Node
                nextElement = null;
            }
        };
        Node? head;
        /* Node? tail; // We could hold a tail reference for faster time complexity on insertion and deletion */

        public SinglyLinkedList()
        {
            head = null;
        }

        public Node GetHead()
        {
            return head;
        }
        public bool IsEmpty()
        {
            if (head == null) // Check whether the head points to null
                return true;
            else
                return false;
        }
        public bool PrintList()
        {
            if (IsEmpty())
            {
                Console.Write("List is Empty!");
                return false;
            }
            Node temp = head;  // Starting from head node
            Console.Write("List : ");

            // Traversing through the List
            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.nextElement;    // Moving on to the temp's nextElement
            }
            Console.WriteLine("null ");
            return true;
        }

        /* Function inserts a value/new Node as the first Element of list -> Time complexity O(1) */
        public void InsertAtHead(int value)
        {
            Node newNode = new Node(); // Creating a new node
            newNode.data = value;
            newNode.nextElement = head; // Linking newNode to head's pointer
            head = newNode; // Head pointing to the start of the list
            Console.Write(value + " Inserted! ");
        }

        /* Function inserts a value/new Node as the last Element of list -> Time complexity O(n) */
        public void InsertAtTail(int value)
        {
            if (IsEmpty())
            {
                InsertAtHead(value); // Head will point to first element of the list      
            }
            else
            {
                Node newNode = new Node();
                Node? last = head;

                // Traversing through the list
                while (last.nextElement != null)
                {
                    last = last.nextElement;
                }

                newNode.data = value;
                Console.Write(value + " Inserted! ");
                newNode.nextElement = null; // Point last's nextElement to null
                last.nextElement = newNode; // Adding the newNode at the end of the list
            }
        }

        /* Searching through a linked list -> Time complexity O(n) */
        public bool Search(int value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return false;
            }

            Node temp = head;

            while (temp != null)
            {
                if (temp.data == value)
                    return true;
                else
                    temp = temp.nextElement;
            }

            return false;
        }

        /* This operation deletes the first node from a list. If the list is empty, the function does nothing -> Time complexity O(1) */
        public bool DeleteAtHead()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return false;
            }
            /* NextNode point to head's nextElement, then it will be deleted from memory by the “.Net garbage collector.” */
            head = head.nextElement;

            return true;
        }

        /* This operation deletes the node based on the value provided by the parameter -> Time complexity O(n) */
        /* Delete at tail will have to use the same method as you can't access the last node without traversing the whole list */
        public bool DeleteByValue(int value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return false;
            }
            Node currentNode = head;
            Node previousNode = null;

            // Deleting value of head if found in first node
            if (currentNode.data == value)
            {
                currentNode = currentNode.nextElement;
                return true;
            }

            previousNode = currentNode;
            currentNode = currentNode.nextElement;

            // Traversing/Searching for Node to Delete
            while (currentNode != null)
            {
                if (currentNode.data == value)
                {
                    // Pointing previousNode's nextElement to currentNode's nextElement
                    previousNode.nextElement = currentNode.nextElement;

                    // Delete currentNode
                    currentNode = previousNode.nextElement;

                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.nextElement; // Pointing current to current's nextElement
            }
            return false;
        }

        /* Find the Length of a Linked List -> Time complexity O(n) */
        public int Length()
        {
            int count = 0;

            if (IsEmpty())
                return count;

            Node currentNode = head;

            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.nextElement;
            }

            return count;
        }

        /* Reverse a Linked List -> Time complexity O(n) */
        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next = null;

            // While traversing the list, swap links
            while (current != null)
            {
                next = current.nextElement;
                current.nextElement = previous; // Reversal
                previous = current;
                current = next;
            }
            head = previous; // Pointing head to start of the list
        }

        /* Detect loop in a linked list -> Time complexity O(n) */
        public bool DetectLoop()
        {
            if (IsEmpty())
                return false;

            // Starting from head of the list
            Node pointer1 = head;
            Node pointer2 = head;

            while (pointer1 != null && pointer2 != null && pointer2.nextElement != null) // Checking if all elements exist 
            {
                pointer1 = pointer1.nextElement; // Iterates one by one
                pointer2 = pointer2.nextElement.nextElement; // Iterates twice

                // If both pointers meet at some point then there is a loop
                if (pointer1 == pointer2)
                    return true;
            }
            return false;
        }

        /* Find middle node of a linked list -> Time complexity O(n) */
        /* Using this algorithm, the calculation of the length and the traversal until the middle are happening side-by-side. */
        public int FindMidNode()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return 0;
            }

            Node? currentNode = head;

            if (currentNode.nextElement == null)
                return currentNode.data;

            Node? midNode = currentNode; // midNode starts at head
            currentNode = currentNode.nextElement.nextElement; // currentNode moves two steps forward

            // Move midNode (slower) one step at a time
            // Move currentNode (faster) two steps at a time
            // When currentNode reaches at end, midNode will be at the middle of list
            while (currentNode != null)
            {
                midNode = midNode.nextElement;
                currentNode = currentNode.nextElement;

                if (currentNode != null)
                    currentNode = currentNode.nextElement;
            }

            // Pointing at middle of the list
            if (midNode != null)
                return midNode.data;

            return 0;
        }

        /* When a linked list is passed to this function, it removes any node (which is a duplicate of another existing node) -> Time complexity O(n2) */
        public void RemoveDuplicates(SinglyLinkedList list)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return;
            }

            Node start = list.head;
            Node startNext = null;

            if (start.nextElement == null)
            {
                Console.WriteLine("List contains only one node.");
                return;
            }

            /* Pick elements one by one -> outer loop */
            while (start != null && start.nextElement != null)
            {
                startNext = start;

                /* Compare the picked element with rest of the elements -> inner loop */
                while (startNext.nextElement != null)
                {
                    if (start.data == startNext.nextElement.data)
                        startNext.nextElement = startNext.nextElement.nextElement;
                    else
                        startNext = startNext.nextElement;
                }
                start = start.nextElement;
            }
        }

        /* When a linked list is passed to this function, it removes any node, which is a duplicate of another existing node -> Time complexity O(n) */
        public void RemoveDuplicatesUsingHashing(SinglyLinkedList list)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return;
            }

            Node current, previous;
            current = head;
            previous = null;

            HashSet<int> hash = new HashSet<int>();

            // Pick elements one by one
            while (current != null)
            {
                // If duplicate then delete it
                if (hash.Contains(current.data))
                {
                    previous.nextElement = current.nextElement;
                    current = null;
                }
                // If the current element does not exist in the set, then add it to the hash set
                else
                {
                    hash.Add(current.data);
                    previous = current;
                }
                current = previous.nextElement;
            }
            list.PrintList();
        }

        /* Given the two lists of A and B, the union is the list that contains elements or objects that belong to either A or to B or to both, but duplicates are not allowed. */
        /* -> Time complexity O(m + n)2 */
        public void Union(SinglyLinkedList firstList, SinglyLinkedList secondList, SinglyLinkedList unionList)
        {
            Node firstListCurrentNode = firstList.head;

            // Traverse first list till the last element and insert all elements to unionList
            while (firstListCurrentNode != null)
            {
                unionList.InsertAtTail(firstListCurrentNode.data);
                firstListCurrentNode = firstListCurrentNode.nextElement;
            }

            Node unionCurrentNode = head;

            // Traverse union list till the last element
            while (unionCurrentNode.nextElement != null)
            {
                unionCurrentNode = unionCurrentNode.nextElement;
            }

            // Link last element of union list to the first element of second list
            unionCurrentNode.nextElement = secondList.head;

            // Remove any duplicates
            RemoveDuplicates(unionList);

            unionList.PrintList();
        }

        /* Given the two lists of A and B, the intersection is the list, which contains all the elements that are common to both the sets, but duplicates are not allowed. */
        /* Time complexity max(O(mn), where m is the size of the first list, and n is the size of the second list. */
        /* Time complexity for RemoveDuplicates() O(min(m,n)2)) */
        public void Intersection(SinglyLinkedList firstList, SinglyLinkedList secondList, SinglyLinkedList intersectionList)
        {
            Node firstListCurrentNode = firstList.head;
            Node secondListCurrentNode = secondList.head;

            // Traverse both lists and store the same element in the resultant list intersectionList
            while (firstListCurrentNode != null)
            {
                while (secondListCurrentNode != null)
                {
                    if (firstListCurrentNode.data == secondListCurrentNode.data)
                        intersectionList.InsertAtTail(firstListCurrentNode.data);

                    secondListCurrentNode = secondListCurrentNode.nextElement;
                }
                firstListCurrentNode = firstListCurrentNode.nextElement;
                secondListCurrentNode = secondList.head;
            }

            RemoveDuplicates(intersectionList); // Remove any duplicates from the intersection list
            intersectionList.PrintList();
        }

        /* Return the node, which is n spaces away from the end of the linked list -> Time complexity O(n) */
        public int FindNthNodeFromEnd(int n)
        {
            int count = 0;
            Node endNode = head; // This pointer will reach the end node
            Node nthNode = head; // This pointer will reach the nth node

            while (count < n)
            {
                if (endNode == null)
                    return -1;

                endNode = endNode.nextElement;
                count++;
            }

            while (endNode != null)
            {
                endNode = endNode.nextElement;
                nthNode = nthNode.nextElement;
            }

            if (nthNode != null)
                return nthNode.data;

            return -1;
        }
    }
}