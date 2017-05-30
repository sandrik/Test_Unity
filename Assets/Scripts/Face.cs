﻿using UnityEngine;

namespace Scripts
{
    public class Face : Align
    {
        protected GameObject targetAux;

        public override void Awake()
        {
            base.Awake();
            targetAux = target;
            target = new GameObject();
            target.AddComponent<Agent>();

        }

        public void OnDestroy()
        {
            Destroy(target);

        }

        public override Steering GetSteering()
        {
            Vector3 direction = targetAux.transform.position - transform.position;

            if (direction.magnitude > 0.0f)
            {
                float targetOrientation = Mathf.Atan2(direction.x, direction.z);
                targetOrientation *= Mathf.Deg2Rad;
                target.GetComponent<Agent>().orientation = targetOrientation;

            }
            return base.GetSteering();
        }
    }
}