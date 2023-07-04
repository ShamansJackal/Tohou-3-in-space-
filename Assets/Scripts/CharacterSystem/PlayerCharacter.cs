using Assets.Scripts.Character.Health;
using Assets.Scripts.CharacterSystem.Movement;
using Assets.Scripts.LevelSystem.Levels;
using Assets.Scripts.WeaponSystem.Weapon;
using Zenject;

namespace Assets.Scripts.CharacterSystem
{
    public class PlayerCharacter : Character
    {
        //[Inject]
        //public BaseLevel Base;

        public Weapon weapon;
        public BaseMovementStrategy movementStrategy;

        public override void Die(DeathContext deathContext)
        {
            onDeath.Invoke(deathContext);
            Destroy(gameObject);
        }
    }
}