using UnityEngine;

namespace Unity_Utilities
{
    public static class RaycastUtil
    {
        
        public static bool RaycastFromCamToTouchPos(out RaycastHit hit, LayerMask mask, Vector2 screenPos,
            bool debug = false)
        {
            var touchPos = screenPos;
            var worldPos = TranslateScreenCoordsToWorldCoords(touchPos, 100);
            if(debug) Debug.DrawRay(Camera.main.transform.position, (worldPos - Camera.main.transform.position), Color.blue);

            return Physics.Raycast(Camera.main.transform.position, (worldPos - Camera.main.transform.position),
                out hit, 100, mask);
        }
    
        public static bool RaycastFromCamToTouchPosNoMask(out RaycastHit hit, Vector2 screenPos)
        {
            var touchPos = screenPos;
            var worldPos = TranslateScreenCoordsToWorldCoords(touchPos, 100);
            Debug.DrawRay(Camera.main.transform.position, (worldPos - Camera.main.transform.position), Color.blue);

            return Physics.Raycast(Camera.main.transform.position, (worldPos - Camera.main.transform.position),
                out hit, 100);
        }
    
    
        public static Vector3 TranslateScreenCoordsToWorldCoords(Vector2 screenPos, float zDistance)
        {
            var screenCoordinates = new Vector3(screenPos.x, screenPos.y, zDistance);
            var worldCoordinates = Camera.main.ScreenToWorldPoint(screenCoordinates);
            return worldCoordinates;
        }
    }
}
