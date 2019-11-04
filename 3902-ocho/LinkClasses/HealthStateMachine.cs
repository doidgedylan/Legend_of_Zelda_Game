

namespace Legend_of_zelda_game
{
    public class HealthStateMachine
    {
        public enum LinkHealth {Full, Half, Empty };
        private LinkHealth health = LinkHealth.Full;
        public LinkHealth Health { get => health; }

        public void BeHurt()
        {
            if (health != LinkHealth.Half)
            {
                health = LinkHealth.Half;
            }
        }

        public void BeEmpty()
        {
            if (health != LinkHealth.Empty)
            {
                health = LinkHealth.Empty;
            }
        }
    }
}
