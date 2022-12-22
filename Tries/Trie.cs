using System.Text;

namespace DataStructuresInCsharp.Tries
{
    internal class TrieNode
    {
        const int ALPHABET_SIZE = 26;

        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
        public bool isEndWord;

        public TrieNode()
        {
            this.isEndWord = false;

            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                this.children[i] = null; ;
            }
        }

        public void MarkAsLeaf()
        {
            this.isEndWord = true;
        }

        public void UnMarkAsLeaf()
        {
            this.isEndWord = false;
        }
    }
    internal class Trie
    {
        const int ALPHABET_SIZE = 26;

        TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public TrieNode GetRoot()
        {
            return root;
        }

        public int GetIndex(char t)
        {
            return t - 'a';
        }

        // Helper Function to return true if currentNode does not have any children
        public bool HasNoChildren(TrieNode currentNode)
        {
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if ((currentNode.children[i]) != null)
                    return false;
            }
            return true;
        }

        /* Function to insert a key, value pair in the Trie -> Time complexity O(n) */
        public void InsertNode(string key)
        {
            if (key == string.Empty)
                return;

            key = key.ToLower();
            TrieNode currentNode = root;
            int index = 0;

            // Iterate the trie with the given character index, if the index points to NULL simply create a TrieNode and go down a level
            for (int level = 0; level < key.Length; level++)
            {
                index = GetIndex(key[level]); // For each character, generate an index using GetIndex()

                if (currentNode.children[index] == null)
                {
                    currentNode.children[index] = new TrieNode();
                    Console.WriteLine(key[level] + " inserted");
                }
                currentNode = currentNode.children[index];
            }

            // Mark the end character as leaf node
            currentNode.MarkAsLeaf();
            Console.WriteLine("'" + key + "' inserted");
        }

        /* Function to search given key in Trie -> Time complexity O(n) */
        public bool SearchNode(string key)
        {
            if (key == string.Empty)
                return false;

            key = key.ToLower();
            TrieNode currentNode = root;
            int index = 0;

            // Iterate the Trie with given character index, if it is NULL at any point then we stop and return false
            // We will return true only if we reach leafNode and have traversed the Trie based on the length of the key
            for (int level = 0; level < key.Length; level++)
            {
                index = GetIndex(key[level]);

                if (currentNode.children[index] == null)
                    return false;

                currentNode = currentNode.children[index];
            }

            if ((currentNode != null) & (currentNode.isEndWord))
                return true;

            return false;
        }

        /* Function to delete given key from Trie -> Time complexity O(n) */
        public void DeleteNode(string key)
        {
            if ((root == null) || (key == string.Empty))
            {
                Console.WriteLine("Null key or Empty trie error");
                return;
            }
            DeleteHelper(key, root, key.Length, 0);
        }

        public bool DeleteHelper(string key, TrieNode currentNode, int length, int level)
        {
            bool deletedSelf = false;

            if (currentNode == null)
            {
                Console.WriteLine("Key does not exist");
                return deletedSelf;
            }

            // Base Case: If we have reached at the node which points to the alphabet at the end of the key
            if (level == length)
            {
                // If there are no nodes ahead of this node in this path then we can delete this node
                if (HasNoChildren(currentNode))
                {
                    currentNode = null; // clear the pointer by pointing it to NULL
                    deletedSelf = true;
                }

                // If there are nodes ahead of currentNode in this path then we cannot delete currentNode. We simply unmark this as leaf
                else
                {
                    currentNode.UnMarkAsLeaf();
                    deletedSelf = false;
                }
            }
            else
            {
                TrieNode childNode = currentNode.children[GetIndex(key[level])];
                bool childDeleted = DeleteHelper(key, childNode, length, level + 1);

                if (childDeleted)
                {
                    // Making children pointer also null: since child is deleted
                    currentNode.children[GetIndex(key[level])] = null;

                    // If currentNode is leaf node, that means currntNode is part of another key, and hence we can not delete this node and it's parent path nodes
                    if (currentNode.isEndWord)
                    {
                        deletedSelf = false;
                    }
                    // If childNode is deleted but if currentNode has more children then currentNode must be part of another key. So, we cannot delete currenNode
                    else if (!HasNoChildren(currentNode))
                    {
                        deletedSelf = false;
                    }
                    // Else we can delete currentNode
                    else
                    {
                        currentNode = null;
                        deletedSelf = true;
                    }
                }
                else
                {
                    deletedSelf = false;
                }
            }
            return deletedSelf;
        }

        /* Find total number of words in a Trie -> Time complexity O(n) */
        public int TotalWords(TrieNode root)
        {
            int result = 0;

            // Leaf denotes end of a word
            if (root.isEndWord)
                result++;

            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (root.children[i] != null)
                    result += TotalWords(root.children[i]);
            }

            return result;
        }

        /* Find all words stored in a Trie -> Time complexity O(n) */
        public List<string> FindWords(TrieNode root)
        {
            List<string> result = new List<string>();
            string word = "";
            GetWords(root, result, 0, ref word);

            return result;
        }

        /* Sorting words from a Trie -> Time complexity O(n) */
        /* Since the children array for each node stores alphabets in alphabetical order, the tree itself is ordered from top to bottom.
           All you need to do is make a pre-order traversal (think of a as the leftmost child and z as the rightmost child), and store the words in a list just like in FindWords(). */
        public List<string> SortTrieArray(TrieNode root, string[] keys)
        {
            List<string> result = new List<string>();

            string word = String.Empty;
            GetWords(root, result, 0, ref word);

            return result;
        }

        private static void GetWords(TrieNode root, List<string> result, int level, ref string word)
        {
            // Leaf denotes end of a word
            if (root.isEndWord)
            {
                // Current word is stored till the 'level' in the word string
                string temp = "";
                for (int x = 0; x < level; x++)
                {
                    temp += word[x];
                }
                result.Add(temp);
            }
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (root.children[i] != null)
                {
                    if (level < word.Length)
                    {
                        StringBuilder sb = new StringBuilder(word);
                        sb[level] = (char)(i + 'a');
                        word = sb.ToString();
                    }
                    else
                    {
                        word += (char)(i + 'a');
                    }
                    GetWords(root.children[i], result, level + 1, ref word);
                }
            }
        }

        /* Implement function, which will find whether or not a given word can be formed by combining two words from a vector -> Time complexity O(m + n2) */
        public static bool IsFormationPossible(string word)
        {
            List<string> keys = new List<string> { "he", "hello", "loworld", "friend" };
            Trie trie = new Trie();

            for (int i = 0; i < keys.Count; i++)
            {
                trie.InsertNode(keys[i]);
            }

            TrieNode currentNode = trie.GetRoot();

            for (int i = 0; i < word.Length; i++)
            {
                char index = (Char)trie.GetIndex(word[i]);

                // If the prefix of word does not exist, word would not either
                if (currentNode.children[index] == null)
                {
                    return false;
                }
                // If the substring of the word exists as a word in trie, check whether rest of the word also exists, if it does return true
                else if ((currentNode.children[index].isEndWord == true) && trie.SearchNode(word.Substring(i + 1)))
                {
                    return true;
                }
                currentNode = currentNode.children[index];
            }

            return false;
        }
    }
}