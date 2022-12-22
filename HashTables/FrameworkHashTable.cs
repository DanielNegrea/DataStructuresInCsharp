namespace DataStructuresInCsharp.HashTables
{
    internal class FrameworkHashTable
    {
        /* An array as a subset of another array -> Time complexity O(m + n) */
        public static bool IsSubset(int[] arr1, int[] arr2)
        {
            if (arr2.Length > arr1.Length)
            {
                return false;
            }

            HashSet<int> ht = new HashSet<int>();

            // Storing all the values of arr1 into a HashSet
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!ht.Contains(arr1[i]))
                    ht.Add(arr1[i]);
            }

            // Loop to check if all elements of arr2 are also in arr1
            for (int i = 0; i < arr2.Length; i++)
            {
                // If key is not found condition will return false. If found it will return iterator to that key
                if (!ht.Contains(arr2[i]))
                    return false;
            }

            return true;
        }

        /* Check if arrays are disjoint (no common elements between them) -> Time complexity O(m + n) */
        public static bool IsDisjoint(int[] arr1, int[] arr2)
        {
            HashSet<int> ht = new HashSet<int>();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (!ht.Contains(arr1[i]))
                    ht.Add(arr1[i]);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                if (ht.Contains(arr2[i]))
                    return false;
            }
            return true;
        }

        /* Find symmetric pairs in an array -> Time complexity O(n) */
        public static string FindSymmetricPairs(int[,] arr, int size)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            string result = "";
            int first, second;

            // Look for second element of each pair in the hash. i.e for pair (1,2) look for key 2 in map.
            // If found then store it in the result array, otherwise insert the pair in hash
            for (int i = 0; i < size; i++)
            {
                first = arr[i, 0];
                second = arr[i, 1];

                if (hashMap.ContainsKey(second) && hashMap[second] == first)
                {
                    // Symmetric Pair found
                    result += "{" + second.ToString() + "," + first.ToString() + "}";
                    result += "{" + first.ToString() + "," + second.ToString() + "}";
                }
                else
                {
                    hashMap[first] = second;
                }
            }
            return result;
        }

        /* Trace the complete path of a journey -> Time complexity O(n) */
        public static string TracePath(Dictionary<string, string> originalMap)
        {
            string result = "";

            // Create a reverse Map of given map i.e if given map has (N,C) then reverse map will have (C,N) as key value pair            
            Dictionary<string, string> reverseMap = new Dictionary<string, string>();

            // To fill reverse map, iterate through the given map
            foreach (string key in originalMap.Keys)
            {
                // Type key stores the key part, and originalMap[key] stores the value part
                reverseMap[originalMap[key]] = key;
            }

            // Traverse original map and see if corresponding key exist in reverse Map. If it doesn't exist then we found our starting point.
            string from = "";

            foreach (string key in originalMap.Keys)
            {
                if (!reverseMap.ContainsKey(key))
                {
                    from = key;
                    break;
                }
            }

            // After starting point is found, simply trace the complete path from original map.
            string to = originalMap[from];

            while (originalMap.ContainsKey(to))
            {
                result += from + "->" + to + " ";
                from = to;
                to = originalMap[to];
            }
            result += from + "->" + to + " ";

            return result;
        }

        /* Find pairs in array that have equal sum -> Time complexity O(n2) */
        /* This solution will only work for distinct integers */
        public static string FindPairEqualSum(int[] arr)
        {
            string result = "";

            // Create HashMap with Key being sum and Value being a pair i.e key = 3 , value = {1,2}
            Dictionary<int, int[]> hashMap = new Dictionary<int, int[]>();
            int sum;
            int[] prevPair = null;

            // Traverse all possible pairs in given arr and store sums in map
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    sum = arr[i] + arr[j];

                    // If the sum is not present in Map then insert it along with pair
                    if (!hashMap.ContainsKey(sum))
                    {
                        int[] tempArr = new int[2];
                        tempArr[0] = arr[i];
                        tempArr[1] = arr[j];
                        hashMap[sum] = tempArr;
                    }
                    // Sum already present in Map
                    else
                    {
                        prevPair = hashMap[sum];

                        // Since array elements are distinct, we don't need to check if any element is common among pairs
                        result += "{" + prevPair[0].ToString() + "," + prevPair[1].ToString() + "}{" + arr[i].ToString() + "," + arr[j].ToString() + "}";
                        return result;
                    }
                }
            }
            return result;
        }

        /* A subarray in which the sum of all elements is zero. The term “subarray” implies that the elements whose sum is 0 must occur consecutively. */
        /* Time complexity O(n) */
        public static bool FindSubArrSumZero(int[] arr)
        {
            // Use Dictionary to store sum as key and index i as value till sum has been calculated
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                // 3 conditions: If 0 exists in the array, If the sum becomes zero, If the sum reverts back to a value, which was already a key in the hash table
                if (arr[i] == 0 || sum == 0 || hashMap.ContainsKey(sum))
                    return true;

                hashMap[sum] = i; // Key will be sum and value will be index
            }

            return false;
        }

        /* Find first unique number in array -> Time complexity O(n) */
        public static int FindFirstUnique(int[] arr)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            // The element is stored as key, and the count of its occurrences is stored as a value
            // Initially the count is 0, but if the same element is encountered again, the count is increased by 1 each time
            for (int i = 0; i < arr.Length; i++)
            {
                if (hashMap.ContainsKey(arr[i]))
                    hashMap[arr[i]]++;
                else
                    hashMap[arr[i]] = 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (hashMap[arr[i]] == 1)
                    return arr[i];
            }
            return -1;
        }

        /* Given the two lists of A and B, the union is the list that contains elements or objects that belong to either A or to B or to both, but duplicates are not allowed. */
        /* -> Time complexity O(m + n) */
        public static void LinkedListUnion()
        {
            LinkedList<int> list1 = new LinkedList<int>();
            list1.AddLast(10);
            list1.AddLast(20);
            list1.AddLast(80);
            list1.AddLast(20);
            list1.AddLast(60);

            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddLast(15);
            list2.AddLast(20);
            list2.AddLast(30);
            list2.AddLast(60);
            list2.AddLast(60);
            list2.AddLast(45);

            if (list1.First == null)
            {
                Console.WriteLine(list2);
                return;
            }
            else if (list2.First == null)
            {
                Console.WriteLine(list1);
                return;
            }

            HashSet<int> visited = new HashSet<int>();
            LinkedList<int> list3 = new LinkedList<int>();

            LinkedListNode<int> node1 = list1.First;
            LinkedListNode<int> node2 = list2.First;

            // Traverse first list till the last element
            while (node1 != null)
            {
                // Add current element of list1 in list3 if it's not repeated yet
                if (!visited.Contains(node1.Value))
                {
                    list3.AddLast(node1.Value);
                    visited.Add(node1.Value);
                }
                node1 = node1.Next;
            }
            // Traverse second list till the last element
            while (node2 != null)
            {
                // Add current element of list2 in list3 if it's not repeated yet
                if (!visited.Contains(node2.Value))
                {
                    list3.AddLast(node2.Value);
                    visited.Add(node2.Value);
                }
                node2 = node2.Next;
            }

            Console.WriteLine(list3);
        }

        /* Intersection is the largest list, which contains all the elements that are common to both the sets, but duplicates are not allowed. */
        /* -> Time complexity O(m + n) */
        public static void LinkedListIntersection()
        {
            LinkedList<int> list1 = new LinkedList<int>();
            list1.AddLast(10);
            list1.AddLast(20);
            list1.AddLast(80);
            list1.AddLast(20);
            list1.AddLast(60);

            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddLast(15);
            list2.AddLast(20);
            list2.AddLast(30);
            list2.AddLast(60);
            list2.AddLast(60);
            list2.AddLast(45);

            HashSet<int> visited = new HashSet<int>();
            LinkedList<int> list3 = new LinkedList<int>();

            LinkedListNode<int> node1 = list1.First;
            LinkedListNode<int> node2 = list2.First;

            // Traverse first list till the last element
            while (node1 != null)
            {
                // Add current element of list1 in hash set if it not repeated yet
                if (!visited.Contains(node1.Value))
                {
                    visited.Add(node1.Value);
                }
                node1 = node1.Next;
            }
            // Traverse second list till the last element
            while (node2 != null)
            {
                // Add current element of list2 in list3 if it's not repeated yet
                if (visited.Contains(node2.Value))
                {
                    list3.AddLast(node2.Value);
                    visited.Remove(node2.Value);
                }
                node2 = node2.Next;
            }

            Console.WriteLine(list3);
        }

        /* Find two numbers that add up to a specified sum -> Time complexity O(n) */
        public static int[] FindSum(int[] arr, int sum)
        {
            HashSet<int> hashSet = new HashSet<int>();
            int[] result = new int[2];

            for (int i = 0; i < arr.Length; i++)
            {
                int temp = sum - arr[i];
                hashSet.Add(arr[i]);

                if (hashSet.Contains(temp))
                {
                    result[0] = arr[i];
                    result[1] = temp;
                }
            }
            return result;
        }
    }
}