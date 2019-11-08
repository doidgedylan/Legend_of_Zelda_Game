

namespace Legend_of_zelda_game
{
    public class HealthStateMachine
    {
        private int Health;
        private int TotalHealth;
        private int damageValue;

        public HealthStateMachine(int totalHealth, int damageValue)
        {
            this.TotalHealth = totalHealth;
            this.Health = totalHealth;
            this.damageValue = damageValue;
        }

        public int GetTotalHealth()
        {
            return TotalHealth;
        }

        public void AddToTotalHealth(int num)
        {
            TotalHealth = TotalHealth + num;
        }

        public int GetHealth()
        {
            return Health;
        }

        public void BeHurt()
        {
            if (Health - damageValue >= 0)
            {
                Health = Health - damageValue;
            }
        }
    }
}
