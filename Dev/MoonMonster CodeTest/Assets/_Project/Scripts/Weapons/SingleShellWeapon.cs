using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

namespace MoonMonster.Codetest
{
    public class SingleShellWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private float _launchForce = 15f;

        public List<Collider> Fire(Transform spawnTransform)
        {
            // Get the bullet from the pool and set its orientation
            GameObject shellInstance = BulletPoolHandler.ShellsPool.Get();
            shellInstance.transform.position = spawnTransform.position;
            shellInstance.transform.rotation = spawnTransform.rotation;

            // Apply the forces to the bullet
            Rigidbody shellRigidbody = shellInstance.GetComponent<Rigidbody>();
            shellRigidbody.linearVelocity = _launchForce * spawnTransform.forward;

            Collider collider = shellInstance.GetComponent<Collider>();
            List<Collider> colliders = new List<Collider>();
            colliders.Add(collider);
            return colliders;
        }

        public void StopFire()
        {

        }
    }
}

