using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAssignment
{
    class Hashtable
    {
        private LinkedList<object> insertionOrder = new LinkedList<object>();
        private LinkedList<Entry>[] table;

        public Hashtable(int size)
        {
            table = new  LinkedList<Entry>[size];
            for(int i = 0; i < size; i++)
            {
                table[i] = new LinkedList<Entry>();
            }
        }

        private int HashIndex(object key)
        {
            int hashCode = key.GetHashCode();
            hashCode = hashCode % table.Length;
            return (hashCode < 0) ? -hashCode : hashCode;
        }

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

        public int Count
        {
            get { return insertionOrder.Count(); }
        }

        public void Put(object key, object value)
        {

        }

        public void Remove(object key)
        {

        }

        public LinkedList<object> GetInsertionOrder()
        {
            return insertionOrder;
        }
    }
}
