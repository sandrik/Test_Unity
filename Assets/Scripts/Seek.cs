using UnityEngine;

namespace Scripts
{
    public class Seek : AgentBehaviour
    {
        public override Steering GetSteering()
        {
            Steering steering = new Steering();
            steering.Linear = target.transform.position - transform.position;
            steering.Linear.Normalize();
            steering.Linear = steering.Linear * agent.maxAccel;
            return steering;
        }
    }
}