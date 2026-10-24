using UnityEngine;

namespace MoonMonster.Codetest
{
    public class Flame : MonoBehaviour
    {
        [SerializeField] float _damage = 1f;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Rigidbody targetRigidbody))
                return;

            if (!targetRigidbody.TryGetComponent(out TankHealth targetHealth))
                return;

            targetHealth.TakeDamage(_damage);
        }
    }
}

