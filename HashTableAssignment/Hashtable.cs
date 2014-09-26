﻿//HashTableAssignment.cs
//Created by Annika Magnusson 2014-09-18
//2014-09-25 Added methods Put and Remove.
//2014-09-26 Added comments
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAssignment
{
    /// <summary>
    /// Creates the table and the linked list, lets the user add, get and remove elements in them.
    /// </summary>
    class Hashtable
    {
        private LinkedList<object> insertionOrder = new LinkedList<object>();
        private LinkedList<Entry>[] table;

        /// <summary>
        /// Sets the size of the table and instantiating all of the elements.
        /// </summary>
        /// <param name="size">size of the array</param>
        public Hashtable(int size)
        {
            table = new  LinkedList<Entry>[size];
            for(int i = 0; i < size; i++)
            {
                table[i] = new LinkedList<Entry>();
            }
        }

        /// <summary>
        /// Property to get the total number of elements in the hashtable
        /// </summary>
        public int Count
        {
            get { return insertionOrder.Count(); }
        }

        /// <summary>
        /// Generates an hash index for a position in the table where to put the element 
        /// </summary>
        /// <param name="key">key to be used to generate hash index</param>
        /// <returns>the generated hash index</returns>
        private int HashIndex(object key)
        {
            int hashCode = key.GetHashCode();
            hashCode = hashCode % table.Length;
            return (hashCode < 0) ? -hashCode : hashCode;
        }

        /// <summary>
        /// Return a value if a specific key exists, otherwise return null
        /// </summary>
        /// <param name="key">key to be matched in table</param>
        /// <returns>the entry value</returns>
        public object Get(object key)
        {
            int hashIndex = HashIndex(key);
            if (table[hashIndex].Contains(new Entry(key, null)))
            {
                Entry entry = table[hashIndex].Find(new Entry(key, null)).Value;
                return entry.Value;
            }

            return null;
        }

        /// <summary>
        /// Puts a new entry in the table if the key doesn't allready exists and then puts the value last in insertionOrder.
        /// </summary>
        /// <param name="key">key to be udes to get an index for table</param>
        /// <param name="value">value to be put in table at the index generated by the key</param>
        /// <returns>true if key isn't in table, false otherwise</returns>
        public bool Put(object key, object value)
        {
            Entry entry = new Entry(key, value);
            int hashIndex = HashIndex(key);
            if (!table[hashIndex].Contains(new Entry(key, null)))
            {
                table[hashIndex].AddFirst(entry);
                insertionOrder.AddLast(entry.Value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes an entry in the table if the key exists and then also removes the value fron insertionOrder.
        /// </summary>
        /// <param name="key">key to be matched in table</param>
        /// <returns>true if entry exists in table and is removed, false otherwise</returns>
        public bool Remove(object key)
        {
            int hashIndex = HashIndex(key);
            if (table[hashIndex].Contains(new Entry(key, null)))
            {
                Entry entry = table[hashIndex].Find(new Entry(key, null)).Value;
                insertionOrder.Remove(entry.Value);
                table[hashIndex].Remove(entry);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the whole LinkedList insertionOrder.
        /// </summary>
        /// <returns>Linked list insertionOrder</returns>
        public LinkedList<object> GetInsertionOrder()
        {
            return insertionOrder;
        }
    }
}
