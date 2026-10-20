using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolHandler : MonoBehaviour
{
    [SerializeField, Required] GameObject _shellPrefab;
    static public ObjectPool<GameObject> ShellsPool
    {
        get;
        private set;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShellsPool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,   // helps catch double-release mistakes
            defaultCapacity: 10,
            maxSize: 50
        );
    }

    // Creates a new pooled GameObject the first time (and whenever the pool needs more).
    private GameObject CreateItem()
    {
        GameObject pooledObject = Instantiate(_shellPrefab);
        pooledObject.name = "PooledShell";
        pooledObject.SetActive(false);
        return pooledObject;
    }
    // Called when an item is taken from the pool.
    private void OnGet(GameObject pooledObject)
    {
        pooledObject.SetActive(true);
    }

    // Called when an item is returned to the pool.
    private void OnRelease(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
    }

    // Called when the pool decides to destroy an item (e.g., above max size).
    private void OnDestroyItem(GameObject pooledObject)
    {
        Destroy(pooledObject);
    }

    private System.Collections.IEnumerator ReturnAfter(GameObject pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        ShellsPool.Release(pooledObject);
    }
}
