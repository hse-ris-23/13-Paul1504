using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4;
using VehicleLibrary1;

namespace Lab13
{
    public class MyObservableCollection<T> : MyCollection<T> where T : ICloneable
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyObservableCollection(int capacity) : base(capacity) { }
        public MyObservableCollection() : base() { }
        public MyObservableCollection(MyObservableCollection<T> table) : base(table) { }

        public new void Add(T data)
        {
            base.Add(data);
            OnCollectionCountChanged("Добавлен элемент", data);
        }

        public new bool Remove(T data)
        {
            bool removed = base.Remove(data);
            if (removed)
            {
                OnCollectionCountChanged("Удален элемент", data);
            }
            return removed;
        }

        public new T this[T data]
        {
            get => base[data];
            set
            {
                if (base.Contains(data))
                {
                    OnCollectionReferenceChanged("Изменен элемент", value);
                }
                base[data] = value;
            }
        }

        protected virtual void OnCollectionCountChanged(string changeType, object changedItem)
        {
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(changeType, changedItem));
        }

        public virtual void OnCollectionReferenceChanged(string changeType, object changedItem)
        {
            CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(changeType, changedItem));
        }
    }
}
