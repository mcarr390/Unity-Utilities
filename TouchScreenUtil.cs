using UnityEngine;

namespace Unity_Utilities
{
    public static class TouchScreenUtil
    {
        /// <summary>
        /// Gets movement from an onscreen joystick that hides itself when not pressed
        /// </summary>
        /// <param name="isTouching"></param>
        /// <param name="currentMainPosition"></param>
        /// <param name="anchorPosition"></param>
        /// <param name="stickObject"></param>
        /// <returns></returns>
        public static Vector2 GetMovementFromJoystick(bool isTouching, Vector2 currentMainPosition, Vector2 anchorPosition, GameObject stickObject)
        {
            float deadZone = Screen.width * .05f;
        
            Vector2 movementDelta;
            if (isTouching)
            {
                stickObject.SetActive(true);
            
                movementDelta = Vector2.ClampMagnitude(currentMainPosition - anchorPosition, deadZone);
        
                stickObject.transform.position = anchorPosition + movementDelta;
            }
            else
            {
                movementDelta = Vector2.zero;
                stickObject.SetActive(false);
            }

            var normalizedMovement = movementDelta.normalized;
            return normalizedMovement;
        }
    }
}
