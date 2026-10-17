using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform _flamethrower;
    private void Start()
    {
        _flamethrower.gameObject.SetActive(false);
    }
    public List<Collider> Fire(Transform spawnTransform)
    {
        _flamethrower.gameObject.SetActive(true);
        _flamethrower = spawnTransform;
        return new List<Collider>();
    }
}
