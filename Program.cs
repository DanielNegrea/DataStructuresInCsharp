using DataStructuresInCsharp.Graphs;
using DataStructuresInCsharp.StacksAndQueues;
using DataStructuresInCsharp.Trees;
using DataStructuresInCsharp.Tries;
using DataStructuresInCsharp.Heaps;
using DataStructuresInCsharp.Arrays;
using DataStructuresInCsharp.LinkedLists;

//Arrays.MaxSumSubarray();

//SinglyLinkedList listA = new SinglyLinkedList();
//SinglyLinkedList listB = new SinglyLinkedList();
//SinglyLinkedList intersectionList = new SinglyLinkedList();

//MyQueue myQueue = new MyQueue();
//string[] result = myQueue.GenerateBinaryNumbers(myQueue, 4);


//MyStack.IsBalanced();

//Stack<int> stack = new Stack<int>();
//MyStack.EvaluatePostFixExpression(stack);

//UndirectedGraph graph1 = new UndirectedGraph(6);
//graph1.BreadthFirstSearch(graph1);

//UndirectedGraph graph2 = new UndirectedGraph(9);
//graph2.NumberOfEdges(graph2);

//DirectedGraph graph3 = new DirectedGraph(5);
//graph3.RemoveEdge(graph3, 2, 3);

//BinarySearchTree bst = new BinarySearchTree(6);
//bst.InsertRecursiveBST(4);
//bst.InsertRecursiveBST(9);
//bst.InsertRecursiveBST(2);
//bst.InsertRecursiveBST(5);
//bst.InsertRecursiveBST(8);
//bst.InsertRecursiveBST(12);
//bst.InsertRecursiveBST(10);
//bst.InsertRecursiveBST(14);
//bst.FindKNodes(2);

///* Trie */
//string[] keys = { "the", "a", "there", "answer", "any", "by", "bye", "their", "abc" };
//Trie trie = new Trie();

//for (int i = 0; i < keys.Length; i++)
//{
//    trie.InsertNode(keys[i]);
//}

//trie.SortTrieArray(trie.GetRoot(), keys);
//Trie.IsFormationPossible("helloworld");

///* Heap */
//MinHeap<int> minHeap = new MinHeap<int>();
//List<int> heapList = new List<int> { 9, 4, 7, 1, -2, 6, 5 };
//Console.Write(minHeap.ConvertMaxHeapToMin(heapList));

//int[] input = { 9, 4, 7, 1, -2, 6, 5 };
////minHeap.BuildHeap(input, input.Length);
////minHeap.FindKSmallest(minHeap, input, 3);

//MaxHeap<int> maxHeap = new MaxHeap<int>();
//maxHeap.BuildHeap(input, input.Length);
//maxHeap.FindKLargest(maxHeap, input, 3);

///* Hash Tables */
//int[] arr1 = { 9, 4, 7, 1, -2, 6, 5 };
//int[] arr2 = { 7, 1, -2 };
//Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.IsSubset(arr1, arr2));
//Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.IsDisjoint(arr1, arr2));

//int[,] matrix = { { 1, 2 }, { 3, 4 }, { 5, 9 }, { 4, 3 }, { 9, 5 } };
//Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.FindSymmetricPairs(matrix, 5));

//Dictionary<string, string> hashMap = new Dictionary<string, string>();
//hashMap["NewYork"] = "Chicago";
//hashMap["Boston"] = "Texas";
//hashMap["Missouri"] = "NewYork";
//hashMap["Texas"] = "Missouri";
//Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.TracePath(hashMap));

int[] arr3 = { 3, 4, 7, 1, 12, 9 };
Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.FindPairEqualSum(arr3));

int[] arr4 = { 6, 4, -7, 3, 12, 9 };
Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.FindSubArrSumZero(arr4));

int[] arr5 = { 2, 3, 9, 2, 3, 6 };
Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.FindFirstUnique(arr5));

int[] arr6 = { 1, 21, 3, 14, 5, 60, 7, 6 };
Console.WriteLine(DataStructuresInCsharp.HashTables.FrameworkHashTable.FindSum(arr6, 81));

//DataStructuresInCsharp.HashTables.FrameworkHashTable.LinkedListUnion();
//DataStructuresInCsharp.HashTables.FrameworkHashTable.LinkedListIntersection();