using System.Collections.Generic;
using UnityEngine;

namespace MoonMonster.Codetest
{
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