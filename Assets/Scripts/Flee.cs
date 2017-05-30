using UnityEngine;

namespace Scripts
{
    public class Flee : AgentBehaviour
    {
        public override Steering GetSteering()
        {
            Steering steering = new Steering();
            steering.Linear = transform.position - target.transform.position;
            steering.Linear.Normalize();
            steering.Linear = steering.Linear * agent.maxAccel;
            return steering;
        }
    }
}