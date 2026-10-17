using NaughtyAttributes;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField, Required] private TankMovement _movement;
        [SerializeField, Required] private TankShooting _shooting;
        [SerializeField, Required] private WeaponHandler _weaponHandler;

        public int PlayerNumber { get; set; }

        private string _movementAxisName;
        private string _turnAxisName;
        private string _fireButtonName;
        private string _selectFirstWeaponButtonName;
        private string _selectSecondWeaponButtonName;
        private string _selectThirdWeaponButtonName;
        
        void Start()
        {            
            _movementAxisName = "Vertical" + PlayerNumber;
            _turnAxisName = "Horizontal" + PlayerNumber;
            _fireButtonName = "Fire" + PlayerNumber;
            _selectFirstWeaponButtonName = "SelectFirstWeapon" + PlayerNumber;
            _selectSecondWeaponButtonName = "SelectSecondWeapon" + PlayerNumber;
            _selectThirdWeaponButtonName = "SelectThirdWeapon" + PlayerNumber;
        }

        void Update()
        {
            _movement.SetMoveInput(Input.GetAxis (_movementAxisName),Input.GetAxis (_turnAxisName));

            if (Input.GetButton(_fireButtonName))
            {
                _shooting.Fire();
            }

            if(Input.GetButton(_selectFirstWeaponButtonName))
            {
                _weaponHandler.SetSelectedWeapon(0);
            }
            if (Input.GetButton(_selectSecondWeaponButtonName))
            {
                _weaponHandler.SetSelectedWeapon(1);
            }
            if (Input.GetButton(_selectThirdWeaponButtonName))
            {
                _weaponHandler.SetSelectedWeapon(4);
            }
        }
    }
}