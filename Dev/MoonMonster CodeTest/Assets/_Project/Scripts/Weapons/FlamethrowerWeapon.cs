using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MoonMonster.Codetest
{
    public class FlamethrowerWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField, Required] private GameObject _flame;
        [SerializeField] private UnityEvent _onFire;
        [SerializeField] private UnityEvent _stopFire;

        private GameObject _flameInstance;

        public List<Collider> Fire(Transform spawnTransform)
        {
            if(_flameInstance == null)
            {
                _flameInstance = Instantiate(_flame, spawnTransform); // Parent the flame on the tank
            }
            _onFire.Invoke();

            Collider collider = _flameInstance.GetComponent<Collider>();
            List<Collider> colliders = new List<Collider>();
            colliders.Add(collider);
            return colliders;
        }

        public void StopFire()
        {
            if (_flameInstance == null) return;
            _stopFire.Invoke();
            Destroy(_flameInstance);
            _flameInstance = null;
        }
    }
}

