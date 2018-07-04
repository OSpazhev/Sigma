using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyList
{
    public class MyList<T>
    {
        public int Count { get; private set; }
        public int Capacity { get => array.Length; }
        private T[] array;

        public T this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                array[index] = value;
            }
        }

        public MyList() : this(0) { }

        public MyList(int size) : this(size, default(T)) { }

        public MyList(int size, T value)
        {
            array = Enumerable.Repeat<T>(value, size).ToArray();
            Count = size;
        }

        public void Add(T value)
        {
            if (Capacity == 0)
            {
                array = new T[4];
            }
            if (Count >= Capacity)
            {
                T[] newArray = new T[Capacity * 2 + 1];
                Array.Copy(array, newArray, Count);
                array = newArray;
            }
            array[Count++] = value;
        }

        public void ForEach(Action<T> action)
        {
            for(int i = 0; i < Count; i++)
            {
                action(array[i]);
            }
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach(T value in range)
            {
                Add(value);
            }
        }

        public void Clear()
        {
            array = new T[0];
            Count = 0;
        }

        public ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(array);
        }

        public bool Contains(T item)
        {
            foreach(T value in array)
            {
                if (value.Equals(item))
                    return true;
            }
            return false;
        }
    }
}
