using DataStructuresInCsharp.LinkedLists;

namespace DataStructuresInCsharp.Graphs
{
    /* Graph implementation using the adjacency list model with directed edges */
    internal class DirectedGraph
    {
        // Definining an array which can hold multiple LinkedLists equal to the number of vertices in the graph
        int vertices;
        SinglyLinkedList[] array;

        public DirectedGraph(int v)
        {
            // Creating a new LinkedList for each vertex/index of the array
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
                array[source].InsertAtHead(destination);
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
            Console.WriteLine("Adjacency List of Directed Graph");

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

        /* Find a vertex from which all the other vertices are reachable */
        /* Kosaraju’s Strongly Connected Component Algorithm -> Time complexity O(v + e) */
        public int FindMotherVertex(DirectedGraph graph)
        {
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);

            int lastVertex = 0; // To store last finished vertex (or mother vertex)
            bool[] visited = new bool[graph.GetVertices()];

            // Complete a DFS traversal and find the last finished vertex
            for (int i = 0; i < graph.GetVertices(); i++)
            {
                if (!visited[i])
                {
                    FindMotherVertex_Helper(graph, i, visited);
                    lastVertex = i;
                }
            }

            // Reset all values in visited[] as false and do DFS beginning from v to check if all vertices are reachable from it or not
            for (int i = 0; i < graph.GetVertices(); i++)
            {
                visited[i] = false;
            }

            // Reset the visited array, and run the DFS only on lastVertex. If it visits all nodes, it is a mother vertex.
            // If not, a mother vertex does not exist. The only limitation in this algorithm is that it can only detect one mother vertex even if others exist.
            FindMotherVertex_Helper(graph, lastVertex, visited);

            for (int i = 0; i < graph.GetVertices(); i++)
            {
                if (visited[i] == false)
                    return -1;
            }

            visited = null;
            return lastVertex;
        }

        static void FindMotherVertex_Helper(DirectedGraph graph, int node, bool[] visited)
        {
            visited[node] = true;

            SinglyLinkedList.Node temp = graph.GetArray()[node].GetHead();

            // Recur for all the vertices adjacent to this vertex
            while (temp != null)
            {
                if (visited[temp.data] == false)
                    FindMotherVertex_Helper(graph, temp.data, visited);

                temp = temp.nextElement;
            }

        }

        /* It takes a source and a destination and tells you whether or not a path exists between the two (from the source to the destination). */
        /* Implemented with the use of DFS. Start from source and if you reach destination, a path then exists -> Time complexity O(v + e) */
        public bool CheckPathBetweenVertices(DirectedGraph graph, int source, int destination)
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

            if (source == destination)
            {
                return true;
            }

            bool[] visited = new bool[graph.GetVertices()];
            Stack<int> stack = new Stack<int>();

            stack.Push(source);
            visited[source] = true;

            int currentNode;
            SinglyLinkedList.Node temp;

            // Traverse while stack is not empty
            while (stack.Count != 0)
            {
                currentNode = stack.Pop();

                // Get adjacent vertices to the currentNode from the array, and push only the unvisited adjacent vertices into stack.
                // Before pushing into stack, check if it's the destination.
                temp = graph.GetArray()[currentNode].GetHead();

                while (temp != null)
                {
                    if (!visited[temp.data])
                    {
                        if (temp.data == destination)
                        {
                            return true;
                        }

                        stack.Push(temp.data);
                        visited[temp.data] = true;
                    }
                    temp = temp.nextElement;
                }
            }

            visited = null;
            return false;
        }

        /* Find shortest path between two vertices. Using BFS algorithm -> Time complexity O(v + e) */
        public int ShortestPath(DirectedGraph graph, int source, int destination)
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 5);
            graph.AddEdge(5, 4);
            graph.AddEdge(2, 4);

            if (source == destination)
                return 0;

            int numOfVertices = graph.GetVertices();
            bool[] visited = new bool[numOfVertices];
            int[] distance = new int[numOfVertices]; // For keeping track of distance of current_node from source

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;

            int currentNode;
            SinglyLinkedList.Node temp;

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();
                temp = graph.GetArray()[currentNode].GetHead();

                while (temp != null)
                {
                    if (!visited[temp.data])
                    {
                        queue.Enqueue(temp.data);
                        visited[temp.data] = true; // Visit the current Node
                        distance[temp.data] = distance[currentNode] + 1;
                    }
                    if (temp.data == destination)
                        return distance[destination];

                    temp = temp.nextElement;
                }
            }

            visited = null;
            distance = null;
            return -1;
        }

        /* Remove edge between two vertices -> Time complexity O(e) */
        public void RemoveEdge(DirectedGraph graph, int source, int destination)
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 0);

            SinglyLinkedList graphList = graph.GetArray()[source];
            SinglyLinkedList.Node currentNode = graphList.GetHead();
            SinglyLinkedList.Node previousNode = null;

            // Deleting value of head if found in first node
            if (currentNode.data == destination)
            {
                currentNode = currentNode.nextElement;
            }

            // Traversing/Searching for Node to Delete
            while (currentNode != null)
            {
                if (currentNode.data == destination)
                {
                    // Pointing previousNode's nextElement to currentNode's nextElement
                    previousNode.nextElement = currentNode.nextElement;

                    // Delete currentNode
                    currentNode = previousNode.nextElement;
                }
                else
                {
                    previousNode = currentNode;
                    currentNode = currentNode.nextElement; // Pointing current to current's nextElement
                }
            }

            graph.GetArray()[source] = graphList;
        }
    }
}