using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class ScriptableObjectList<T> : ScriptableObject, IList<T> where T : Object
    {
        public List<T> list = new List<T>();

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
        public void Add(T item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(T item) => list.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public bool Remove(T item) => list.Remove(item);
        public int Count => list.Count;
        public bool IsReadOnly => false;
        public int IndexOf(T item) => list.IndexOf(item);
        public void Insert(int index, T item) => list.Insert(index, item);
        public void RemoveAt(int index) => list.RemoveAt(index);

        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
}