using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class TankShooting : MonoBehaviour
    {
        [SerializeField] private bool _lookAtMouse;
        [SerializeField, Required] private Transform _fireTransform;
        [SerializeField] private float _fireDelay = 0.3f;
        [SerializeField, Required] private GameObject _turret;
        [SerializeField] private float _angleOffset = 90f;
        [SerializeField, Required] private GameObject _weaponPrefab;

        private float _reloadCountdown;
        private bool _fired;
        private Camera _camera;
        private Collider _collider;
        private IWeapon _activeWeapon;
        private GameObject _weaponInstance;

        
        private void Start()
        {
            // Set the weapon the player starts with to the first one in its inventory
            WeaponHandler weaponHandler = GetComponent<WeaponHandler>();
            if (weaponHandler != null)
            {
                _weaponPrefab = weaponHandler.GetActiveWeapon();
            }
            _camera = Camera.main;
            _collider = gameObject.GetComponent<Collider>();
            _weaponInstance = Instantiate(_weaponPrefab, _fireTransform);
            _activeWeapon = _weaponInstance.GetComponent<IWeapon>();
        }

        private void Update()
        {
            if(_lookAtMouse)
                LookAtMousePosition();
            
            if (_fired)
            {                
                if(_reloadCountdown <= 0)
                    _fired = false;
                else
                    _reloadCountdown -= Time.deltaTime;
            }
        }

        public void LookAtTarget(Transform target)
        {
            if (target == null)
                return;
            
            var dir = target.position - _turret.transform.position;
            dir.y = 0;
            dir.Normalize();
            
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg - _angleOffset;
            _turret.transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);
        }

        public void Fire()
        {
            if(_fired)
                return;

            List<Collider> shellColliders = _activeWeapon.Fire(_fireTransform);
            // Ignore collision between your own shot shells & yourself
            foreach(var shellCollider in shellColliders)
            {
                Physics.IgnoreCollision(shellCollider, _collider);
                foreach(var shellColliderB in shellColliders) // Ignore collision between your own bullets, TODO: avoid duplicate ignorecollision
                {
                    Physics.IgnoreCollision(shellCollider, shellColliderB);
                }
            }
            
            _fired = true;
            _reloadCountdown = _fireDelay;
        }

        public void StopFire()
        {
            if (_activeWeapon == null) return;
            _activeWeapon.StopFire();
        }
        
        private void LookAtMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(mousePos);
            
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 targetPos = ray.GetPoint(distance);
                var dir = targetPos - _turret.transform.position;
                dir.y = 0;
                dir.Normalize();
            
                var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg - _angleOffset;
                _turret.transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);
            }
        }

        public void SetActiveWeaponPrefab(GameObject activeWeapon)
        {
            if (_weaponInstance != null && activeWeapon == _weaponPrefab) return;


            _activeWeapon.StopFire();
            Destroy(_weaponInstance);

            _weaponPrefab = activeWeapon;
            _weaponInstance = Instantiate(_weaponPrefab, _fireTransform);
            _activeWeapon = _weaponInstance.GetComponent<IWeapon>();
        }
    }
}