using UnityEngine;
using System.Collections.Generic;

namespace Scripts
{
    class Leave : AgentBehaviour
    {
        public float escapeRadius;
        public float dangerRadius;
        public float timeToTarget = 0.1f;

        public override Steering GetSteering()
        {
            Steering steering = new Steering();
            Vector3 direction = transform.position - target.transform.position;
            float distance = direction.magnitude;

            if (distance > dangerRadius)
            {
                return steering;
            }
            float reduce;

            if (distance < escapeRadius)
            {
                reduce = 0;
            }
            else
            {
                reduce = distance / dangerRadius * agent.maxSpeed;

            }
            float targetSpeed = agent.maxSpeed - reduce;
            Vector3 desiredVelocity = direction;
            desiredVelocity.Normalize();
            desiredVelocity *= targetSpeed;
            steering.Linear = desiredVelocity - agent.velocity;
            steering.Linear /= timeToTarget;

            if (steering.Linear.magnitude > agent.maxAccel)
            {
                steering.Linear.Normalize();
                steering.Linear *= agent.maxAccel;
            }
            return steering;

        }
    }
}
