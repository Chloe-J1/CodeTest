

using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    List<Collider> Fire(Transform spawnTransform);
    void StopFire();
}
