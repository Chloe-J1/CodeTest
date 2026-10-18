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
        private string _selectNextAxisName;
        
        void Start()
        {            
            _movementAxisName = "Vertical" + PlayerNumber;
            _turnAxisName = "Horizontal" + PlayerNumber;
            _fireButtonName = "Fire" + PlayerNumber;
            _selectFirstWeaponButtonName = "SelectFirstWeapon" + PlayerNumber;
            _selectSecondWeaponButtonName = "SelectSecondWeapon" + PlayerNumber;
            _selectThirdWeaponButtonName = "SelectThirdWeapon" + PlayerNumber;
            _selectNextAxisName = "SelectNextWeapon" + PlayerNumber;
        }

        void Update()
        {
            _movement.SetMoveInput(Input.GetAxis (_movementAxisName),Input.GetAxis (_turnAxisName));

            if (Input.GetButtonDown(_fireButtonName))
            {
                _shooting.Fire();
            }
            if(Input.GetButtonUp(_fireButtonName))
            {
                _shooting.StopFire();
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
                _weaponHandler.SetSelectedWeapon(2);
            }
            float scrollValue = Input.GetAxis(_selectNextAxisName);
            if (scrollValue > 0f)
            {
                _weaponHandler.SelectNextWeapon();
            }
            if (scrollValue < 0f)
            {
                _weaponHandler.SelectPreviousWeapon();
            }
        }
    }
}