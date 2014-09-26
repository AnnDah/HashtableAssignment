//HashTableAssignment.cs
//Created by Annika Magnusson 2014-09-18
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
    /// Container for the key and value. 
    /// </summary>
    class Entry
    {
        private object key;
        private object value;

        /// <summary>
        /// Sets the values to the class variables key and value on creation of entry object
        /// </summary>
        /// <param name="key">the objects key</param>
        /// <param name="value">the objects value</param>
        public Entry(object key, object value)
        {
            this.key = key;
            this.value = value;
        }

        /// <summary>
        /// Property to get data in the variable key
        /// </summary>
        public object Key
        {
            get { return key; }
        }

        /// <summary>
        /// Property to get data i the variable value
        /// </summary>
        public object Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Used to be able to find a specific entry element.
        /// </summary>
        /// <param name="obj">object to be matched</param>
        /// <returns>the key if it matched</returns>
        public override bool Equals(object obj)
        {
            Entry keyValue = (Entry)obj;
            return key.Equals(keyValue.key);
        }
    }
}
