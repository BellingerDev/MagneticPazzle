using UnityEngine;


namespace Player
{
    public class PlayerProperties : MonoBehaviour
    {
        public struct MagneticProperties
        {
            public float force;
            public float radius;
        }

        public struct MoveProperties
        {
            public float linearVelocity;
            public float angularVelocity;
        }

        public MagneticProperties[] magneticProperties;
        public int currentMagneticPropertiesLevel;
    }
}
