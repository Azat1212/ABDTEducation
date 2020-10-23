using System;
using System.Collections;

namespace _1
{
    public class MyClass<T> : IEnumerable, IEnumerator
    {
        public MyClass(T[] array)
        {
            this.array = array;
        }

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

        private T[] array;
        int position = -1;

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        object IEnumerator.Current => throw new NotImplementedException();
        public T Current
        {
            get
            {
                if (position == -1 || position >= array.Length)
                    throw new InvalidOperationException();
                return this[position];
            }
        }

        public void Reset()
        {
            position = -1;
        }



    }
}