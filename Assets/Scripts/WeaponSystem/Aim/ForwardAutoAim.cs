using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Aim
{
    public class ForwardAutoAim : MonoBehaviour
    {
        [SerializeField]
        private WeaponAimedAttack _aim;

        private void Update()
        {
            _aim.SetShootPositionAndDirection(transform.position, transform.up);
        }
    }
}
