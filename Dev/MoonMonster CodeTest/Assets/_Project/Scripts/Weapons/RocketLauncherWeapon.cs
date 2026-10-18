using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class RocketLauncherWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField, Required] private Rigidbody _rocket;
        [SerializeField] private float _shootDistance = 15f;
        [SerializeField] private float _travelTime = 2f;

        public List<Collider> Fire(Transform spawnTransform)
        {
            Rigidbody rocketInstance =
                    Instantiate(_rocket, spawnTransform.position, spawnTransform.rotation) as Rigidbody;

            Vector3 Target = spawnTransform.position + spawnTransform.forward * _shootDistance;

            rocketInstance.linearVelocity = CalculateVelocity(spawnTransform.position, Target);

            List<Collider> colliders = new List<Collider>();
            colliders.Add(rocketInstance.GetComponent<Collider>());
            return colliders;
        }

        Vector3 CalculateVelocity(Vector3 start, Vector3 target)
        {
            float vx = (target.x - start.x) / _travelTime;
            float vz = (target.z - start.z) / _travelTime;
            float vy = ((target.y - start.y) - 0.5f * Physics.gravity.y * Mathf.Pow(_travelTime, 2)) / _travelTime; // Determine the velocity that creates the arch trajectory
            return new Vector3(vx, vy, vz);
        }

        public void StopFire()
        {

        }
    }
}

