using DataStructuresInCsharp.LinkedLists;

namespace DataStructuresInCsharp.Graphs
{
    internal class UndirectedGraph
    {
        int vertices;
        SinglyLinkedList[] array;

        public UndirectedGraph(int v)
        {
            array = new SinglyLinkedList[v];
            vertices = v;

            for (int i = 0; i < v; i++)
            {
                array[i] = new SinglyLinkedList();
            }
        }

        public void AddEdge(int source, int destination)
        {
            if (source < vertices && destination < vertices)
            {
                array[source].InsertAtHead(destination);
                array[destination].InsertAtHead(source);
            }
        }

        public int GetVertices()
        {
            return vertices;
        }

        public SinglyLinkedList[] GetArray()
        {
            return array;
        }

        public void PrintGraph()
        {
            Console.WriteLine("Adjacency List of Undirected Graph");

            SinglyLinkedList.Node temp;

            for (int i = 0; i < vertices; i++)
            {
                Console.Write("|" + i + "| => ");
                temp = (array[i]).GetHead();

                while (temp != null)
                {
                    Console.Write("[" + temp.data + "] -> ");
                    temp = temp.nextElement;
                }
                Console.WriteLine("NULL");
            }
        }

        /* Implmentation of BFS using Queues -> Time complexity O(v + e) */
        public string BreadthFirstSearch(UndirectedGraph graph)
        {
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);

            string result = "";

            if (graph.GetVertices() < 1)
                return result;

            // Bool Array to hold the history of visited nodes. Make a node visited whenever you push it into the queue
            // All set to false by the bool default value
            bool[] visited = new bool[graph.GetVertices()];

            for (int i = 0; i < GetVertices(); i++)
            {
                if (!visited[i])
                    BreadthFirstSearch_Helper(graph, i, visited, ref result);
            }

            visited = null;
            return result;
        }

        static void BreadthFirstSearch_Helper(UndirectedGraph graph, int source, bool[] visited, ref string result)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;

            int currentNode;
            SinglyLinkedList.Node temp;

            while (queue.Count != 0)
            {
                // Dequeue a vertex/node from queue and add it to result
                currentNode = queue.Dequeue();

                result += currentNode.ToString();

                // Get adjacent vertices to the currentNode from the array, and if they are not already visited then enqueue them in the Queue
                temp = graph.GetArray()[currentNode].GetHead();

                while (temp != null)
                {
                    if (!visited[temp.data])
                    {
                        queue.Enqueue(temp.data);
                        visited[temp.data] = true; // Visit the current Node
                    }
                    temp = temp.nextElement;
                }
            }
        }

        /* Implmentation of BFS using Stacks -> Time complexity O(v + e) */
        public string DepthFirstSearch(UndirectedGraph graph)
        {
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);

            string result = "";

            if (graph.GetVertices() < 1)
                return result;

            bool[] visited = new bool[graph.GetVertices()];

            for (int i = 0; i < graph.GetVertices(); i++)
            {
                if (!visited[i])
                    DepthFirstSearch_Helper(graph, i, visited, ref result);
            }

            visited = null; // Delete visited

            return result;
        }

        static void DepthFirstSearch_Helper(UndirectedGraph graph, int source, bool[] visited, ref string result)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(source);
            visited[source] = true;

            int currentNode;
            SinglyLinkedList.Node temp;

            while (stack.Count != 0)
            {
                // Pop a vertex/node from stack and add it to the result
                currentNode = stack.Pop();
                result += currentNode.ToString();

                // Get adjacent vertices to the currentNode from the array, and if they are not already visited then push them in the stack
                temp = graph.GetArray()[currentNode].GetHead();

                while (temp != null)
                {
                    if (!visited[temp.data])
                    {
                        stack.Push(temp.data);
                        visited[temp.data] = true; // Visit the node
                    }
                    temp = temp.nextElement;
                }
            }
        }

        /* Detecting if there is cycle in a Graph -> Time complexity O(v + e) */
        public bool DetectCycleInGraph(UndirectedGraph graph)
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 3);

            int numOfVertices = graph.GetVertices();

            // Boolean Array to hold the history of visited nodes (by default false); make a node visited whenever you traverse it
            bool[] visited = new bool[numOfVertices];

            // Boolean Array of vertices which will be called recursively
            bool[] recursiveNodes = new bool[numOfVertices];

            for (int i = 0; i < numOfVertices; i++)
            {
                if (DetectCycleRecursively_Helper(graph, i, visited, recursiveNodes))
                    return true;
            }
            return false;
        }

        static bool DetectCycleRecursively_Helper(UndirectedGraph graph, int source, bool[] visited, bool[] recursiveNodes)
        {
            // Check if current node is being visited in the same recursive call
            if (visited[source] == false)
            {
                // Set recursive array and visited to true
                visited[source] = true;
                recursiveNodes[source] = true;

                int adjacentData;
                SinglyLinkedList.Node adjacentNode = graph.GetArray()[source].GetHead();

                while (adjacentNode != null)
                {
                    // Access adjacent node and repeat algorithm
                    adjacentData = adjacentNode.data;

                    if ((!visited[adjacentData]) && DetectCycleRecursively_Helper(graph, adjacentData, visited, recursiveNodes))
                        return true;  // Loop found
                    else if (recursiveNodes[adjacentData])
                        return true;

                    adjacentNode = adjacentNode.nextElement;
                }
            }
            recursiveNodes[source] = false;
            return false;
        }

        /* Count the number of edges in an undirected graph -> Time complexity O(v + e) */
        public int NumberOfEdges(UndirectedGraph graph)
        {
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 5);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(5, 3);
            graph.AddEdge(5, 6);
            graph.AddEdge(3, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(6, 8);
            graph.AddEdge(6, 4);
            graph.AddEdge(7, 8);

            int countEdges = 0;
            SinglyLinkedList.Node temp;

            for (int i = 0; i < graph.GetVertices(); i++)
            {
                temp = graph.GetArray()[i].GetHead();

                while (temp != null)
                {
                    countEdges++;
                    temp = temp.nextElement;
                }
            }

            // Because this is an undirected graph, count must be halfed
            return countEdges / 2;
        }

        /* Algorithm to check if Graph is a Tree -> Time complexity O(v + e) */
        /* Conditions: no cycles, and all vertices are connected */
        public bool GraphIsTree(UndirectedGraph graph)
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 4);

            bool[] visited = new bool[graph.GetVertices()];

            if (GraphIsTree_CheckCycleHelper(graph, 0, visited, -1))
                return false;

            for (int i = 0; i < graph.GetVertices(); i++)
            {
                if (!visited[i])
                    return false;
            }

            return true;
        }

        static bool GraphIsTree_CheckCycleHelper(UndirectedGraph graph, int vertex, bool[] visited, int parent)
        {
            visited[vertex] = true;

            // Recursive calls for all the vertices adjacent to this vertex
            SinglyLinkedList.Node temp = graph.GetArray()[vertex].GetHead();

            while (temp != null)
            {
                // If an adjacent is not visited, then make recursive call on the adjacent
                if (!visited[temp.data])
                {
                    if (GraphIsTree_CheckCycleHelper(graph, temp.data, visited, vertex))
                        return true;
                }
                else if (temp.data != parent)
                    return true;

                temp = temp.nextElement;
            }

            return false;
        }
    }
}