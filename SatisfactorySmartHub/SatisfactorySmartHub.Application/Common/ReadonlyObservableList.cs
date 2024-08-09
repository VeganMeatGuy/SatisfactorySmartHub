using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Common;

public sealed class ReadonlyObservableList<T> : INotifyCollectionChanged, IReadOnlyCollection<T>
{
    private ICollection<T> _collection;

    internal ReadonlyObservableList()
    {
        _collection = new List<T>();
    }

    internal ReadonlyObservableList(ICollection<T> collection)
    {
        _collection = collection;
    }

    public int Count => _collection.Count;

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

    public void Update()
    {
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
