using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Steering
    {
        public float angular;
        public Vector3 Linear;

        public Steering()
        {
            angular = 0.0f;
            Linear = new Vector3();
        }
    }
}
