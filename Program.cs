using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUcache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRU newCache = new LRU(10);
            string SearchValue;
            newCache.AddToCache(1, "1");
            newCache.AddToCache(2, "2");
            newCache.AddToCache(3, "3");
            newCache.AddToCache(4, "4");
            newCache.AddToCache(5, "5");
            newCache.AddToCache(6, "6");
            newCache.AddToCache(7, "7");
            newCache.AddToCache(8, "8");
            newCache.AddToCache(9, "9");
            newCache.AddToCache(10, "10");
            newCache.AddToCache(11, "11");
            Console.WriteLine(newCache.cacheList.Count);
            foreach (var item in newCache.cacheList)
            {
                Console.WriteLine(item);
            }

            newCache.Retrieve(14, out SearchValue);
            //newCache.Retrieve("three", out SearchValue);
            //newCache.Retrieve("ten", out SearchValue);
            //Console.WriteLine("----------");
            foreach (var item in newCache.cacheList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
