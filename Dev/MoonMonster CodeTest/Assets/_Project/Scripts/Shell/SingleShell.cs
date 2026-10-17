using System.Collections.Generic;
using UnityEngine;

public class SingleShell : MonoBehaviour, IWeapon
{
    [SerializeField] private float _launchForce = 15f;
    [SerializeField] private Rigidbody _shell;

    public List<Collider> Fire(Transform spawnTransform)
    {
        Rigidbody shellInstance =
                Instantiate(_shell, spawnTransform.position, spawnTransform.rotation) as Rigidbody;
        
        shellInstance.linearVelocity = _launchForce * spawnTransform.forward;

        Collider collider = shellInstance.GetComponent<Collider>();
        List<Collider> colliders = new List<Collider>();
        colliders.Add(collider);
        return colliders;
    }
}
