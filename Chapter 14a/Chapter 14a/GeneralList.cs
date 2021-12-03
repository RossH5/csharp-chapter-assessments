using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    class GeneralList<T>
    {
        private T[] objectArray;
        private int objectIndex;

        public GeneralList(int capacity)
        {
            objectArray = new T[capacity];
        }
        public void Add(T newObject)
        {
            if (this.objectIndex >= this.objectArray.Length)
            {
                throw new InvalidOperationException("Array is full");
            }
            this.objectArray[this.objectIndex] = newObject;
            this.objectIndex++;
        }


    }
}
