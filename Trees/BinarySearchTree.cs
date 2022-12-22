namespace DataStructuresInCsharp.Trees
{
    internal class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;
        public Node()
        {
            value = 0;
            leftChild = null;
            rightChild = null;
        }

        public Node(int value)
        {
            this.value = value;
            leftChild = null;
            rightChild = null;
        }
    }
    internal class BinarySearchTree
    {
        Node root;

        public BinarySearchTree(int rootValue)
        {
            root = new Node(rootValue);
        }

        public BinarySearchTree()
        {
            root = null;
        }

        public Node GetRoot()
        {
            return root;
        }

        /* Traversal strategy called "In-Order Traversal" in a BST -> Time complexity O(n) */
        /* In this traversal, the elements are traversed in the left-root-right order */
        public void InOrderTraversalPrint(Node currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraversalPrint(currentNode.leftChild);
                Console.WriteLine(currentNode.value);
                InOrderTraversalPrint(currentNode.rightChild);
            }
        }

        /* Traversal strategy called "Pre-Order Traversal" in a BST -> Time complexity O(n) */
        /* In this traversal, the elements are traversed in the root-left-right order */
        public void PreOrderTraversalPrint(Node currentNode)
        {
            if (currentNode != null)
            {
                Console.WriteLine(currentNode.value);
                PreOrderTraversalPrint(currentNode.leftChild);
                PreOrderTraversalPrint(currentNode.rightChild);
            }
        }

        /* Traversal strategy called "Post-Order Traversal" in a BST -> Time complexity O(n) */
        /* In this traversal, the elements are traversed in the left-right-root order */
        public void PostOrderTraversalPrint(Node currentNode)
        {
            if (currentNode != null)
            {
                PostOrderTraversalPrint(currentNode.leftChild);
                PostOrderTraversalPrint(currentNode.rightChild);
                Console.WriteLine(currentNode.value);
            }
        }

        /* BST iterative insertion implementation -> Time complexity on average O(log(n)), on worst case O(n) */
        public void InsertIterativeBST(int value)
        {
            if (GetRoot() == null)
            {
                root = new Node(value);
                return;
            }

            // Starting from the root
            Node currentNode = root;
            Node parent = root;

            // While we get to the null node
            while (currentNode != null)
            {
                parent = currentNode; // Update the parent
                if (value < currentNode.value)
                {
                    // If newValue < currentNode.val, iterate to the left subtree
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    // If newValue >= currentNode.val, iterate to the right subtree
                    currentNode = currentNode.rightChild;
                }
            }

            // By now, we will have the parent of the null node where we have to insert the newValue
            if (value < parent.value)
            {
                // If newValue < parent.value, insert into the leftChild
                parent.leftChild = new Node(value);
            }
            else
            {
                // If newValue >= parent.value insert into the rightChild
                parent.rightChild = new Node(value);
            }
        }

        /* BST recursive insertion implementation -> Time complexity on average O(log(n)), on worst case O(n) */
        public void InsertRecursiveBST(int value)
        {

            if (GetRoot() == null)
            {
                root = new Node(value);
                return;
            }
            Insert_Helper(this.GetRoot(), value);
        }

        public Node Insert_Helper(Node currentNode, int value)
        {
            if (currentNode == null)
            {
                return new Node(value);
            }
            else if (currentNode.value > value)
            {
                currentNode.leftChild = Insert_Helper(currentNode.leftChild, value);
            }
            else
            {
                currentNode.rightChild = Insert_Helper(currentNode.rightChild, value);
            }

            return currentNode;
        }

        /* Searching in a Binary Search Tree -> Time complexity on average O(log(n)), on worst case O(n) */
        public Node SearchBST(int value)
        {
            Node currentNode = root;

            while (currentNode != null && currentNode.value != value)
            {
                // The loop will run until the currentNode IS NOT null and until we get to our value
                if (value < currentNode.value)
                {
                    currentNode = currentNode.leftChild; // Traverse to the left subtree
                }
                else
                {
                    currentNode = currentNode.rightChild; // Traverse to the right subtree
                }
            }
            // After the loop, we'll have either the searched value or null in case the value was not found
            return currentNode;
        }

        /* Implementation of deletion in a BST -> Time complexity on average O(log(n)), on worst case O(n) */
        public bool DeleteInBST(int value)
        {
            if (GetRoot() == null)
                return false;

            Node currentNode = root;
            Node parentNode = root;

            // Condition for case when Tree has only a root node
            if (currentNode.value == value && currentNode.leftChild == null && currentNode.rightChild == null)
            {
                root = null;
                return true;
            }

            // Finding the node to delete
            while (currentNode != null && currentNode.value != value)
            {
                parentNode = currentNode;
                if (value < currentNode.value)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;
            }

            // Condition for case when node to delete is a leaf node
            if (currentNode.leftChild == null && currentNode.rightChild == null)
            {
                DeleteLeafNode_DeleteBSTHelper(currentNode, parentNode);
                return true;
            }

            // Condition for case when node to delete has only one child
            else if (currentNode.rightChild == null)
            {
                if (root.value == currentNode.value)
                {
                    root = currentNode.leftChild;
                    return true;
                }
                else if (currentNode.value < parentNode.value)
                {
                    parentNode.leftChild = currentNode.leftChild;
                    return true;
                }
                else
                {
                    parentNode.rightChild = currentNode.leftChild;
                    return true;
                }
            }
            else if (currentNode.leftChild == null)
            {
                if (root.value == currentNode.value)
                {
                    root = currentNode.rightChild;
                    return true;
                }
                else if (currentNode.value < parentNode.value)
                {
                    parentNode.leftChild = currentNode.rightChild;
                    return true;
                }
                else
                {
                    parentNode.rightChild = currentNode.rightChild;
                    return true;
                }
            }
            else
            {
                Node leastNode = FindLeastNode_DeleteBSTHelper(currentNode.rightChild); // Find least value node in right-subtree of current Node
                int temp = leastNode.value; // Set CurrentNode's data to the least value in its right-subtree
                DeleteInBST(temp);
                currentNode.value = leastNode.value; // Delete the leafNode which had the least value

                return true;
            }

            return false;
        }

        // Helper function to find least value node in right-subtree of currentNode
        private Node FindLeastNode_DeleteBSTHelper(Node currentNode)
        {
            while (currentNode.leftChild != null)
            {
                currentNode = currentNode.leftChild;
            }

            return currentNode;
        }

        private void DeleteLeafNode_DeleteBSTHelper(Node leafNode, Node parentNode)
        {
            if (leafNode.value < parentNode.value)
                parentNode.leftChild = null;
            else
                leafNode.rightChild = null;
        }

        /* Find minimum value in a BST -> Time complexity on average O(h), on worst case the BST will be left-skewed therefore O(n) */
        public int FindMinValue()
        {
            if (GetRoot() == null)
                return -1;

            Node currentNode = root;

            if (currentNode.leftChild == null && currentNode.rightChild == null)
                return -1;

            while (currentNode.leftChild != null)
            {
                currentNode = currentNode.leftChild;
            }

            return currentNode.value;
        }

        /* Return the “kth” maximum number from the tree -> Time complexity O(n) */
        public int FindKthMaxValue(int k)
        {
            if (GetRoot() == null || k <= 0)
                return -1;

            Node rootNode = GetRoot();
            List<int> treeValues = new List<int>();

            // Perform In-Order Traversal to get sorted array (ascending order)
            FindKthMaxValue_InOrderTraversalHelper(rootNode, treeValues);

            return treeValues[treeValues.Count - k];
        }

        /* Helper recursive function to traverse tree using in order traversal */
        private static void FindKthMaxValue_InOrderTraversalHelper(Node rootNode, List<int> treeValues)
        {
            if (rootNode != null)
            {
                FindKthMaxValue_InOrderTraversalHelper(rootNode.leftChild, treeValues);
                treeValues.Add(rootNode.value);
                FindKthMaxValue_InOrderTraversalHelper(rootNode.rightChild, treeValues);
            }
        }

        /* Find ancestors for a given node value -> Time complexity O(log(n)) */
        public string FindAncestors(int k)
        {
            if (GetRoot() == null || k <= 0)
                return "";

            Node currentNode = GetRoot();
            string result = "";

            while (currentNode != null && currentNode.value != k)
            {
                if (k < currentNode.value)
                {
                    result = currentNode.value.ToString() + " " + result;
                    currentNode = currentNode.leftChild;
                }
                else if (k > currentNode.value)
                {
                    result = currentNode.value.ToString() + " " + result;
                    currentNode = currentNode.rightChild;
                }
            }
            return result;
        }

        /* Find height of the root node -> Time complexity O(n) */
        public int FindRootTreeHeight()
        {
            if (GetRoot() == null)
                return -1;

            Node currentNode = GetRoot();
            int countLeft = 0;
            int countRight = 0;

            while (currentNode != null)
            {
                if (currentNode.leftChild != null)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;
                countLeft++;
            }

            currentNode = GetRoot();

            while (currentNode != null)
            {
                if (currentNode.rightChild != null)
                    currentNode = currentNode.rightChild;
                else
                    currentNode = currentNode.leftChild;

                countRight++;
            }

            if (countLeft > countRight)
                return countLeft - 1;
            else
                return countRight - 1;
        }

        /* Implement a function which finds and returns nodes at k distance from the root in the given binary tree -> Time complexity O(n) */
        public string FindKNodes(int distance)
        {
            string result = string.Empty;
            Node rootNode = GetRoot();

            FindKNodes_Helper(rootNode, distance, ref result);

            return result;
        }

        /* Helper recursive function to traverse tree and append all the nodes at k distance into result string */
        private static void FindKNodes_Helper(Node root, int distance, ref string result)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                result = result + root.value.ToString() + ",";
            }
            else
            {
                // Decrement k at each step till you reach at the leaf node, or when k == 0 then append the Node's data into result string
                FindKNodes_Helper(root.leftChild, distance - 1, ref result);
                FindKNodes_Helper(root.rightChild, distance - 1, ref result);
            }
        }
    }
}