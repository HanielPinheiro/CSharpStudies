using ByteBank.Architecture.MVC.Model.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Util
{
    public class GenericList<T>
    {
        const int DefaultCapacity = 4;

        T[] _items;
        private int _count;

        public GenericList(int capacity = DefaultCapacity)
        {
            _items = new T[capacity];
        }

        public int Count { get { return _count; } } // Equivalent a Count => _count. Essa forma se chama definição de corpo da expressão

        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _count) value = _count;
                if (value != _items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(_items, 0, newItems, 0, _count);
                    _items = newItems;
                }
            }
        }

       

        public void Add(T item)
        {
            if (_count == Capacity) Capacity = _count * 2;
            _items[_count] = item;
            _count++;
            OnChanged();
        }
        public event EventHandler Changed;

        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public T this[int index]
        {
            get => _items[index];
            set
            {
                _items[index] = value;
                OnChanged();
            }
        }


        public override bool Equals(object other) =>
            Equals(this, other as GenericList<T>);

        static bool Equals(GenericList<T> a, GenericList<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a._count != b._count)
                return false;
            for (int i = 0; i < a._count; i++)
            {
                if (!object.Equals(a._items[i], b._items[i]))
                {
                    return false;
                }
            }
            return true;
        }        

        public static bool operator ==(GenericList<T> a, GenericList<T> b) =>
            Equals(a, b);

        public static bool operator !=(GenericList<T> a, GenericList<T> b) =>
            !Equals(a, b);
    }  
}
