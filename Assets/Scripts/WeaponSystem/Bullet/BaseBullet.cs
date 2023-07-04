using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Bullet
{
    public abstract class BaseBullet : MonoBehaviour
    {
        public abstract void Init(BulletContext context);
    }
}
