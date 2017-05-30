using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class AgentBehaviour : MonoBehaviour
    {
        public GameObject target;
        protected Agent agent;
        public float maxSeep;
        public float maxRotation;
        public float maxAccel;
        public float maxAngularAccel;

        public float MapToRange(float rotation)
        {
            rotation %= 360.0f;

            if (Mathf.Abs(rotation) > 180.0f)
            {
                if (rotation < 0)
                {
                    rotation += 360.0f;
                }
                else
                {
                    rotation -= 360f;
                }
            }
            return rotation;
        }

        public virtual void Awake()
        {
            agent = gameObject.GetComponent<Agent>();
        }

        public virtual void Update()
        {
            agent.SetSteering(GetSteering());
        }

        public virtual Steering GetSteering()
        {
            return new Steering();
        }
    }
}