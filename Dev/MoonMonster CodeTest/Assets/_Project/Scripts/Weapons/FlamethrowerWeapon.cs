using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerWeapon : MonoBehaviour, IWeapon
{
    [SerializeField, Required] private GameObject _flame;

    private GameObject _flameInstance;

    public List<Collider> Fire(Transform spawnTransform)
    {
        _flameInstance =
                Instantiate(_flame, spawnTransform); // Parent the flame on the tank

        Collider collider = _flameInstance.GetComponent<Collider>();
        List<Collider> colliders = new List<Collider>();
        colliders.Add(collider);
        return colliders;
    }

    public void StopFire()
    {
        if (_flameInstance == null) return;
        Destroy(_flameInstance);
    }
}
