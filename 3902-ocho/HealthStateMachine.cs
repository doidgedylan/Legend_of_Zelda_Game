using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class HealthStateMachine
    {
        private enum LinkHealth {Full, Half, Empty };
        private LinkHealth health = LinkHealth.Full;

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
