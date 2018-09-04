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
            array = Enumerable.Repeat(value, size).ToArray();
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

        public void AddRange(IEnumerable<T> range)
        {
            foreach (T value in range)
            {
                Add(value);
            }
        }

        public ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(array);
        }

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            if (count == 1)
            {
                if (comparer.Compare(array[index], item) == 0)
                {
                    return index;
                }
                else
                {
                    return -1;
                }
            }
            int left = index;
            int right = index + count - 1;
            int middle = (left + right) / 2;
            if (comparer.Compare(item, array[middle]) <= 0)
            {
                return BinarySearch(left, middle - left + 1, item, comparer);
            }
            else
            {
                return BinarySearch(middle + 1, right - middle, item, comparer);
            }
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return BinarySearch(0, Count, item, comparer);
        }

        public int BinarySearch(T item)
        {
            return BinarySearch(item, Comparer<T>.Default);
        }

        public void Clear()
        {
            array = new T[0];
            Count = 0;
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

        public MyList<U> ConvertAll<U>(Converter<T, U> converter)
        {
            MyList<U> result = new MyList<U>(Count);
            for(int i = 0; i < Count; i++)
            {
                result[i] = converter(array[i]);
            }
            return result;
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, Count);
        }

        public void CopyTo(int index, T[] array, int arrayindex, int count)
        {
            Array.Copy(this.array, index, array, arrayindex, count);
        }

        public bool Exists(Predicate<T> predicate)
        {
            return !Find(predicate).Equals(default(T));
        }

        public T Find(Predicate<T> predicate)
        {
            for(int i = 0; i < Count; i++)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public List<T> FindAll(Predicate<T> predicate)
        {
            var result = new List<T>();
            for (int i = 0; i < Count; i++)
            {
                if (predicate(array[i]))
                {
                    result.Add(array[i]);
                }
            }
            return result.Count == 0 ? null : result;
        }

        public int FindIndex(int startIndex, int count, Predicate<T> predicate)
        {
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindIndex(int startIndex, Predicate<T> predicate)
        {
            return FindIndex(startIndex, Count, predicate);
        }

        public int FindIndex(Predicate<T> predicate)
        {
            return FindIndex(0, Count, predicate);
        }

        public T FindLast(Predicate<T> predicate)
        {
            for(int i = Count - 1; i > 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<T> predicate)
        {
            for (int i = startIndex + count - 1; i >= startIndex; i--)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindLastIndex(int startIndex, Predicate<T> predicate)
        {
            return FindLastIndex(startIndex, Count, predicate);
        }

        public int FindLastIndex(Predicate<T> predicate)
        {
            return FindLastIndex(0, Count, predicate);
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(array[i]);
            }
        }

        public MyList<T> GetRange(int index, int count)
        {
            MyList<T> result = new MyList<T>();
            var resultArray = new T[count];
            Array.Copy(array, index, resultArray, 0, count);
            result.AddRange(resultArray);
            return result;
        }

        public int IndexOf(T item)
        {
            return FindIndex(x => x.Equals(item));
        }

        public int IndexOf(T item, int index)
        {
            return FindIndex(index, x => x.Equals(item));
        }

        public int IndexOf(T item, int index, int count)
        {
            return FindIndex(index, count, x => x.Equals(item));
        }

        public void Insert(int index, T item)
        {
            //Add(default(T));
            //Array.Copy(array, index, array, index + 1, Count - index);
            //array[index] = item;
            InsertRange(index, new T[] { item });
        }

        public void InsertRange(int index, IEnumerable<T> items)
        {
            AddRange(new List<T>(items.Count()));
            Array.Copy(array, index, array, index + items.Count(), Count - index);
            Array.Copy(items.ToArray(), 0, array, index, items.Count());
        }

        public int LastIndexOf(T item)
        {
            return FindLastIndex(x => x.Equals(item));
        }

        public int LastIndexOf(T item, int index)
        {
            return FindLastIndex(index, x => x.Equals(item));
        }

        public int LastIndexOf(T item, int index, int count)
        {
            return FindLastIndex(index, count, x => x.Equals(item));
        }

        public bool Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveAll(Predicate<T> predicate)
        {
            int removed = 0;
            for (int i = 0; i < Count; i++)
            {
                if (predicate(array[i]))
                {
                    removed++;
                }
                else
                {
                    array[i - removed] = array[i];
                }
            }
            Count -= removed;
            return removed;
        }

        public void RemoveAt(int index)
        {
            RemoveRange(index, 1);
        }

        public void RemoveRange(int index, int count)
        {
            Array.Copy(array, index + count, array, index, Count - index - count);
            Count -= count;
        }
    }
}
