using MoonMonster.Codetest;
using System.Collections.Generic;
using UnityEngine;

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
        _selectedWeaponIndex = selectedWeaponIndex;
        _shooting.SetActiveWeaponPrefab(_weaponPrefabs[selectedWeaponIndex]);
    }
}
