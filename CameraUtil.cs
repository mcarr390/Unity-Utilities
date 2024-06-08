using UnityEngine;

namespace Unity_Utilities
{
    public static class CameraUtil 
    {
        public static Vector3 GetCameraRelativeInput(Vector3 rawPlayerInput)
        {
            var input = Vector2.ClampMagnitude(rawPlayerInput, 1);

            Vector3 camF = Camera.main.transform.forward;
            Vector3 camR = Camera.main.transform.right;

            camF.y = 0;
            camR.y = 0;

            camF = camF.normalized;
            camR = camR.normalized;

            return (camF * input.y + camR * input.x);
        } 
    }
}
