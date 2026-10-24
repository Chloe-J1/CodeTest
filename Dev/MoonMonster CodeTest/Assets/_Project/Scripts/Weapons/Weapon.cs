using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
    // Base class that weapons can use to implement shooting mechanics
    public class Weapon : MonoBehaviour
    {
        virtual public List<Collider> Fire(Transform spawnTransform)
        {
            return new List<Collider>();
        }
        virtual public void StopFire()
        {

        }
    }
}