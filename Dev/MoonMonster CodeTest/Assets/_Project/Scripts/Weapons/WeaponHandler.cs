using MoonMonster.Codetest;
using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class WeaponHandler : MonoBehaviour
    {
        private int _selectedWeaponIndex = 0;
        public List<GameObject> _weaponPrefabs = new List<GameObject>();
        private TankShooting _shooting;

        private void Start()
        {
            _shooting = gameObject.GetComponent<TankShooting>();
        }

        public void SetSelectedWeapon(int selectedWeaponIndex)
        {
            if (_selectedWeaponIndex > _weaponPrefabs.Count || _selectedWeaponIndex < 0) // Don't go out of bounds
                return;
            _selectedWeaponIndex = selectedWeaponIndex;
            _shooting.SetActiveWeaponPrefab(_weaponPrefabs[_selectedWeaponIndex]);
        }
        public void SelectNextWeapon()
        {
            ++_selectedWeaponIndex;
            if (_selectedWeaponIndex > _weaponPrefabs.Count - 1)
            {
                _selectedWeaponIndex = 0; // Go back to start
            }
            _shooting.SetActiveWeaponPrefab(_weaponPrefabs[_selectedWeaponIndex]);

        }

        public void SelectPreviousWeapon()
        {
            --_selectedWeaponIndex;
            if (_selectedWeaponIndex < 0)
            {
                _selectedWeaponIndex = _weaponPrefabs.Count - 1; // Jump to end
            }
            _shooting.SetActiveWeaponPrefab(_weaponPrefabs[_selectedWeaponIndex]);
        }
    }
}

