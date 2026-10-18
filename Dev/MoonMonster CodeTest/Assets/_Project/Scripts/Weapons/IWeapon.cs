using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public interface IWeapon
    {
        List<Collider> Fire(Transform spawnTransform);
        void StopFire();
    }
}