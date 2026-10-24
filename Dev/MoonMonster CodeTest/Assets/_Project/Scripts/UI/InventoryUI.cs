using NaughtyAttributes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField, Required] private TMP_Text _selectedWeaponText;
        private WeaponHandler _weaponHandler;

        public void AddListener(WeaponHandler weaponHandler)
        {
            _weaponHandler = weaponHandler;
            _weaponHandler._activeWeaponChanged.AddListener(UpdateText);
            UpdateText(_weaponHandler.GetActiveWeapon());
        }

        private void UpdateText(GameObject weapon)
        {
            _selectedWeaponText.text = weapon.name.Replace("PF_", "");
        }

        private void OnDestroy()
        {
            if (_weaponHandler != null)
            {
                _weaponHandler._activeWeaponChanged.RemoveListener(UpdateText);
            }
        }
    }
}