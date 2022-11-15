using UnityEngine;

namespace Unity_Utilities
{
    public static class Vector3Util
    {

        public static Vector3 GetClosestPointWithinRadius(Vector3 origin, Vector3 destination, float radius, bool debug = false)
        {
            var goal = destination + radius * (origin - destination) / (origin - destination).magnitude;
            if (debug)
            {
                Debug.DrawLine(origin, goal, Color.green, 3);
            }
        
            return goal;
        }
    
        public static Vector3 GetPositionAroundACircle(Vector3 center, float radius, float percentage)
        {
            var internalLerp = percentage * 6.3f;
            var x = radius * Mathf.Cos(internalLerp) + center.x;
            var z = radius * Mathf.Sin(internalLerp) + center.z;

            var position = new Vector3(x, 0, z);

            return position;
        }
    
        public static Vector3 GetDirectionToTarget(Vector3 myPosition, Vector3 targetPosition)
        {
            // gets absolute direction in full vector3 format
            Vector3 direction = (targetPosition - myPosition);
            return direction;
        }
        public static Vector3 GetNormalizedDirectionToTarget(Vector3 myPosition, Vector3 targetPosition)
        {
            // gets the normalized direction
            Vector3 direction = (targetPosition - myPosition);
            return direction.normalized;
        }
        public static float GetDotProductDirectionToTarget(Transform me, Vector3 targetPosition)
        {
            // returns a number from 1 to -1 to tell us how "In front" of our position the target is
            // 1 being directly in front, -1 being behind
            Vector3 normalizedDirection = (targetPosition - me.position).normalized;
            float dot = Vector3.Dot(me.forward, normalizedDirection);
            return dot;
        }
        public static bool CheckFieldOfView(float angleFOV, float dotProductResult)
        {
            if (dotProductResult >= Mathf.Cos(angleFOV))
            {
                return true;
            }
            else return false;
        }

        public static float AngleDir (Vector3 fwd, Vector3 targetDir, Vector3 up) {
            Vector3 perp = Vector3.Cross(fwd, targetDir);
            float dir = Vector3.Dot(perp, up);

            return dir;

            // if (dir > 0) {
            //     return 1;
            // } else if (dir < 0) {
            //     return -1;
            // } else {
            //     return 0;
            // }
        }
    
        public static void RotateTowardTarget(GameObject me, GameObject target, bool onlyY, float rotationSpeed)
        {

            Quaternion desiredRotation = Quaternion.LookRotation(target.transform.position - me.transform.position);
            if (onlyY)
            {
                desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y, 0);
            }
            me.transform.rotation = Quaternion.Slerp(me.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
        public static void RotateTowardTarget(Transform me, Vector3 target, bool onlyY, float rotationSpeed)
        {

            Quaternion desiredRotation = Quaternion.LookRotation(target - me.position);
            if (onlyY)
            {
                desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y, 0);
            }
            me.rotation = Quaternion.Slerp(me.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
        
    
    }
}