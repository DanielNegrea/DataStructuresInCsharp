namespace DataStructuresInCsharp.HashTables
{
    internal class HashEntry
    {
        public string key;
        public int value;
        public HashEntry next;

        public HashEntry()
        {
            key = "";
            value = -1;
            next = null;
        }

        public HashEntry(string key, int value)
        {
            this.key = key;
            this.value = value;
            next = null;
        }
    }

    /* Class to represent entire hash table */
    internal class HashTable
    {
        HashEntry[] bucket = null;
        int size;
        int slots;

        // HashEntry bucket
        public HashTable(int s)
        {
            bucket = new HashEntry[s];

            // Initialise all elements of array as NULL
            for (int i = 0; i < s; i++)
                bucket[i] = null;

            slots = s;
            size = 0;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }

        // This is the hash function using arithmetic modulo
        public int GetIndex(string key)
        {
            int Key = 0;

            for (int i = 0; i < key.Length; i++)
            {
                Key = 37 * Key + key[i];
            }
            if (Key < 0)
                Key *= -1;

            return Key % slots;
        }

        /* Time complexity O(1) on average and O(n) in the worst-case */
        public void Insert(string key, int value)
        {
            // Apply hash function to find index for given key
            int hashIndex = GetIndex(key);

            if (bucket[hashIndex] == null)
            {
                bucket[hashIndex] = new HashEntry(key, value);
                size++;
            }
            // Find next free space
            else
            {
                HashEntry temp = bucket[hashIndex];

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new HashEntry(key, value);
                size++;
            }
        }

        public void Display()
        {
            HashEntry temp;

            for (int i = 0; i < slots; i++)
            {
                if (bucket[i] != null)
                {
                    Console.Write("HashIndex : " + i + " ");
                    temp = bucket[i];

                    while (temp != null)
                    {
                        Console.Write("(key = " + temp.key + " , value = " + temp.value + " )");
                        temp = temp.next;
                    }
                }
                Console.WriteLine("");
            }
        }

        /* Function to resize hash table to avoid collisions */
        public void Resize()
        {
            Console.WriteLine("Resize");
            slots *= 2;
            HashEntry[] tempBucket = new HashEntry[slots];
            int hashIndex;
            HashEntry tmp = null;

            for (int i = 0; i < slots; i++)
                tempBucket[i] = null;

            HashEntry temp = null;

            for (int i = 0; i < slots / 2; i++)
            {
                if (bucket[i] != null)
                {
                    temp = bucket[i];
                    while (temp != null)
                    {
                        hashIndex = GetIndex(temp.key);

                        if (tempBucket[hashIndex] == null)
                            tempBucket[hashIndex] = new HashEntry(temp.key, temp.value);
                        else // Find next free space
                        {
                            tmp = tempBucket[hashIndex]; ;
                            while (tmp.next != null)
                            {
                                tmp = tmp.next;
                            }
                            tmp.next = new HashEntry(temp.key, temp.value);
                        }
                        temp = temp.next;
                    }
                }
            }
            bucket = tempBucket;
        }

        /* Time complexity O(1) on average and O(n) in the worst-case */
        public int Search(string key)
        {
            int hashIndex = GetIndex(key);

            if (bucket[hashIndex] == null)
            {
                Console.WriteLine("Value Not Found!");
                return -1;
            }

            if (bucket[hashIndex].key == key)
            {
                return bucket[hashIndex].value;
            }
            else // Find next free space
            {
                HashEntry temp = bucket[hashIndex];

                while (temp != null)
                {
                    if (temp.key == key)
                    {
                        return temp.value;
                    }
                    temp = temp.next;
                }
                Console.WriteLine("Value Not Found!");
                return -1;
            }
        }

        /* Time complexity O(1) on average and O(n) in the worst-case */
        public void Delete(string key)
        {
            int hashIndex = GetIndex(key);

            if (bucket[hashIndex] == null)
            {
                Console.WriteLine("Value To Be Deleted Not Found!");
                return;
            }
            if (bucket[hashIndex].key == key)
            {
                if (bucket[hashIndex].next != null)
                {
                    bucket[hashIndex] = bucket[hashIndex].next;
                }
                else
                {
                    bucket[hashIndex] = null;
                }
            }
            else // Find next free space
            {
                HashEntry temp = bucket[hashIndex];
                HashEntry prev = bucket[hashIndex];

                while (temp != null)
                {
                    if (temp.key == key)
                    {
                        if (temp.next != null)
                        {
                            prev.next = temp.next;
                            temp = temp.next;
                        }
                        else
                            prev.next = null;

                        return;
                    }
                    prev = temp;
                    temp = temp.next;
                }
                Console.WriteLine("Value to be deleted not Found!");
            }
        }
    }
}