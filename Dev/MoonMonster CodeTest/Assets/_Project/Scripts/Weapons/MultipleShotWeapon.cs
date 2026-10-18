using System.Collections.Generic;
using UnityEngine;

public class MultipleShotWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float _launchForce = 30f;
    [SerializeField] private int _nrShells = 3;
    [SerializeField] private Rigidbody _shellRigidbody;

    public List<Collider> Fire(Transform spawnTransform)
    {
        List<Collider> colliders = new List<Collider>();
        float totalRotationReach = 45f;
        float stepAngle = totalRotationReach / _nrShells;
        float rotationAngle = stepAngle / 2f - totalRotationReach / 2f; // Start rotation on left hand side of the tank and rotate with stepAngle degrees to the right
        for (int index = 0; index < _nrShells; index++)
        {
            Quaternion rotation = spawnTransform.rotation * Quaternion.Euler(0f, rotationAngle, 0f);
            Rigidbody shellInstance =
                Instantiate(_shellRigidbody, spawnTransform.position, rotation) as Rigidbody;

            shellInstance.linearVelocity = _launchForce * shellInstance.transform.forward;
            rotationAngle += stepAngle;

            Collider collider = shellInstance.GetComponent<Collider>();
            colliders.Add(collider);
        }
        
        return colliders;
    }

    public void StopFire()
    {
    }
}
