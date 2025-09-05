using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : Component
{
    private readonly Queue<T> _pool = new();
    private readonly T _prefab;
    private readonly Transform _parent;

    public int CountInactive => _pool.Count;

    public Pool(T prefab, Transform parent, int prewarmCount = 0)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < prewarmCount; i++)
        {
            var item = Object.Instantiate(_prefab, _parent);
            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
        }
    }

    public T Get()
    {
        T item = _pool.Count > 0 ? _pool.Dequeue() : Object.Instantiate(_prefab, _parent);
        
        if (item.transform.parent != _parent)
            item.transform.SetParent(_parent, false);

        item.gameObject.SetActive(true);
        return item;
    }

    public void Release(T item)
    {
        if (!item) return;
        item.gameObject.SetActive(false);
        item.transform.SetParent(_parent, false);
        _pool.Enqueue(item);
    }

    public void ClearAll()
    {
        while (_pool.Count > 0)
        {
            var item = _pool.Dequeue();
            if (item) Object.Destroy(item.gameObject);
        }
    }
}