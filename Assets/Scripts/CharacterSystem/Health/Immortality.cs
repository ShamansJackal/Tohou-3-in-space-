namespace Assets.Scripts.Character.Health
{
    public class Immortality: BaseHealth
    {
        public BaseHealth baseHealth;

        public override int CurrentHealth => baseHealth.CurrentHealth;

        public override int MaxHealth => baseHealth.MaxHealth;

        public override int Heal(int health) => baseHealth.Heal(health);

        public override int TakeDamage(int damage) => 0;
    }
}
