using Assets.Scripts.WeaponSystem.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem.Enemy
{
    public class CommandsFollower : MonoBehaviour
    {
        [SerializeField]
        private Weapon _weapon;

        public Weapon Weapon => _weapon;

        private Vector2? _targetPosition;
        private float _targetAngle;

        private float _stepPosition;
        private float _stepAngle;
        private float _stopingDistance;

        public bool MovingToTarget => _targetPosition != null;

        public void Move(Vector2 target, float speed, float stoppingDistance = 0.01f)
        {
            _stepPosition = speed;
            _targetPosition = target;
            _stopingDistance = stoppingDistance;
        }

        public void Rotate(float angle, float speed, bool clockwise)
        {

        }

        private void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, _targetAngle), _stepAngle * Time.deltaTime);
            if (_targetPosition != null)
            {
                var newPosition = Vector2.MoveTowards(transform.position, _targetPosition.Value, _stepPosition * Time.deltaTime);
                if ((_targetPosition.Value - newPosition).magnitude < _stopingDistance) _targetPosition = null;
                transform.position = newPosition;
            }
        }
    }
}
