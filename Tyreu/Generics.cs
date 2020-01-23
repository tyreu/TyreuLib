using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication1
{
    class Tyreu<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerator<T>, IDisposable
    {
        int position = -1;
        bool @readonly = false;
        T[] elements;
        public int Count => elements.Length;
        //конструктор по умолчанию
        public Tyreu() => elements = new T[0];
        //конструктор с параметрами
        public Tyreu(int b) => elements = new T[b];
        //индексатор
        public T this[int i]
        {
            get => elements[i];
            set => elements[i] = value;
        }
        #region реализация IEnumerator
        object IEnumerator.Current=> elements[position];
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }
        void IEnumerator.Reset()
        {
            position = -1;
        }
        #endregion
        #region реализация IEnumerator<T>
        T IEnumerator<T>.Current => elements[position];
        #endregion
        #region реализация IDisposable
        void IDisposable.Dispose() => ((IEnumerator)this).Reset();
        #endregion
        #region реализация IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => this;
        #endregion
        #region реализация IEnumerable<T>
        public IEnumerator<T> GetEnumerator() => this;
        #endregion
        #region реализация ICollection<T>
        public bool IsReadOnly => @readonly;
        public void Add(T item)
        {
            var newArray = new T[elements.Length + 1];
            elements.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = item;
            elements = newArray;
        }
        public void Clear() => elements = new T[0];
        public bool Contains(T item) => elements.Contains(item);
        public void CopyTo(T[] array, int arrayIndex)
        {
            var arr = array as object[];
            if (arr == null)
                throw new ArgumentException("Требуется массив на входе");
            for (int i = 0; i < Count; i++)
                arr[arrayIndex++] = elements[i];
        }
        public bool Remove(T item)
        {
            if (item != null)
            {
                elements = elements.Where(x => !x.Equals(item)).ToArray();
                return true;
            }
            return false;
        }
        #endregion
        #region реализация IList<T>        
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (elements[i].Equals(item))
                    return i;
            return -1;
        }
        public void Insert(int index, T item)
        {
            if (index < Count && index >= 0)
            {
                for (int i = Count - 1; i > index; i--)
                    elements[i] = elements[i - 1];
                elements[index] = item;
            }
        }
        public void RemoveAt(int index) => elements = elements.Where(x => !x.Equals(elements[index])).ToArray();
        #endregion
        public override string ToString() => $"Пользовательская коллекция из {Count} элементов";
    }
}
