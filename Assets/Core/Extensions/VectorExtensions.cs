using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 XZ(this Vector3 v)
        {
            return new Vector3(v.x, 0, v.z);
        }

        public static Vector3 Y(this Vector3 v)
        {
            return new Vector3(0, v.y, 0);
        }
    }
}
