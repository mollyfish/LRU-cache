using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUcache
{
    class LRU
    {
        // to be passed in in Main
        public int maxListLength;
        // each instance needs a dictionary and a linked list
        // the dictionary stores the key:value pairs
        // the linked list stores the order of use by storing the keys
        public Dictionary<int, string> cacheDictionary;
        public LinkedList<int> cacheList;

        public LRU(int max)
        {
            // set max length for the linked list
            // construct new dictionary and new linked list
            this.maxListLength = max;
            this.cacheDictionary = new Dictionary<int, string>();
            this.cacheList = new LinkedList<int>();
        }

        // function to pull an item out of the cache if it exists, 
        // then reorder the linked list to reflect the new use order
        public bool Retrieve(int key, out string SearchValue)
        {
            if(cacheDictionary.ContainsKey(key))
            {
                // look for a key
                SearchValue = cacheDictionary[key];
                Console.WriteLine(key + ": " + SearchValue);

                // Move the matching node to be the first node.
                LinkedListNode<int> match = cacheList.Find(key);
                cacheList.Remove(key);
                cacheList.AddFirst(match);

                return true;
            } else
            {
                SearchValue = key.ToString();
                AddToCache(key, SearchValue);
                return true;
            }
        }
        void Clear()
        {
            // cleans up internal state
        }

        // adds key:value pairs to the dictionary if they do not already exist
        public void AddToCache(int key, string value)
        {
            // checks to see if the given key already exists in the dictionary
            if (cacheDictionary.ContainsKey(key))
            {
                throw new ArgumentException("Dictionary already contains an entry with that key");
            }
            // checks to see if the linked list is over capacity
            if (cacheList.Count > this.maxListLength - 1)
            {
                // if the list is at capacity, remove the least recently used item
                Console.WriteLine("list is too long, deleting " + cacheList.Last.Value);
                Console.WriteLine(cacheList.Last.Value);
                cacheDictionary.Remove(cacheList.Last.Value);
                cacheList.RemoveLast();
                // add the most recently used item to the front of the list
                Console.WriteLine("adding " + value);
                cacheDictionary.Add(key, value);
                cacheList.AddFirst(key);
            }
            else {
                // if the list is not at capacity and  the key doesn't already exist, 
                // add the key value pair to the dictionary and add the key to the front of the list
                cacheDictionary.Add(key, value);
                cacheList.AddFirst(key);
            }
        }
    }
}
