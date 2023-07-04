using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Interfaces
{
    public interface IWeaponAim
    {
        void AimendAttack();
        void SetShootPositionAndDirection(Vector2 position, Vector2 direction);
    }
}
