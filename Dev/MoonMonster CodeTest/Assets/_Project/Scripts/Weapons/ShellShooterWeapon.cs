using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MoonMonster.Codetest
{
    public class ShellShooterWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private float _launchForce = 30f;
        [SerializeField] private int _nrShells = 3;
        [SerializeField] private UnityEvent _onFire;

        public List<Collider> Fire(Transform spawnTransform)
        {
            List<Collider> colliders = new List<Collider>();
            float totalRotationReach = 45f;
            float stepAngle = totalRotationReach / _nrShells;
            float rotationAngle = stepAngle / 2f - totalRotationReach / 2f; // Start rotation on left hand side of the tank and rotate with stepAngle degrees to the right
            for (int index = 0; index < _nrShells; index++)
            {
                Quaternion rotation = spawnTransform.rotation * Quaternion.Euler(0f, rotationAngle, 0f);
                // Get the bullet from the pool and set its orientation
                GameObject shellInstance = BulletPoolHandler.ShellsPool.Get();
                shellInstance.transform.position = spawnTransform.position;
                shellInstance.transform.rotation = rotation;
                
                // Apply the forces to the bullet
                Rigidbody shellRigidbody = shellInstance.GetComponent<Rigidbody>();
                shellRigidbody.linearVelocity = _launchForce * shellRigidbody.transform.forward;
                rotationAngle += stepAngle;

                Collider collider = shellRigidbody.GetComponent<Collider>();
                colliders.Add(collider);
            }

            _onFire.Invoke();
            return colliders;
        }

        public void StopFire()
        {
        }
    }
}

