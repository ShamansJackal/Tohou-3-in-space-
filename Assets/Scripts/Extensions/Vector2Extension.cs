using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class Vector2Extension
    {
        public static Quaternion LookAt(this Vector2 direction)
        {
            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
