using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    class Arrive : AgentBehaviour
    {
        public float targetRadius;
        public float slowRadius;
        public float timeToTarget = 0.1f;

        public override Steering GetSteering()
        {
            Steering steering = new Steering();
            Vector3 direction = target.transform.position - transform.position;
            float distance = direction.magnitude;
            float targetSpeed;

            if (distance < targetRadius)
            {
                return steering;
            }
            if (distance > slowRadius)
            {
                targetSpeed = agent.maxSpeed;
            }
            else
            {
                targetSpeed = agent.maxSpeed * distance / slowRadius;
            }
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
