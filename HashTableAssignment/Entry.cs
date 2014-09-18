using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAssignment
{
    class Entry
    {
        private object key;

        public object Key
        {
            get { return key; }
            set { key = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Entry(object key, object value)
        {
            this.key = key;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            Entry keyValue = (Entry)obj;
            return key.Equals(keyValue.key);
        }
    }
}
