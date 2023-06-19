using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool autoExpand { get; set; }
    public Transform Container { get; }

    private List<T> pool;

    public PoolSystem(T prefab, int count, Transform container, bool autoExpand)
    {
        this.Prefab = prefab;
        this.Container = container;
        this.autoExpand = autoExpand;
        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();
        for(int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.Prefab, this.Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach(var elem in pool)
        {
            if (!elem.gameObject.activeInHierarchy)
            {
                element = elem;
                element.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeelement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }

        if (this.autoExpand)
        {
            return this.CreateObject(true);
        }

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }
}

