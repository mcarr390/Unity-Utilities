using UnityEngine;

namespace Unity_Utilities
{
    public static class UiUtil
    {
        /// <summary>
        /// Will return a resized image box based on the drag start position and the current drag end position.
        /// Make sure to "catch" the initial start position before running this method in an update loop so
        /// that that only the current mouse position is updated. NOTE: Make sure to set the anchor position of your
        /// rect to bottom left.
        /// </summary>
        /// <param name="mousePosition"> the current mouse position (this is meant to be updated in a loop)</param>
        /// <param name="startPosition"> the position captured OnClick</param>
        /// <param name="rectTransform"> the rectTransform to be resized.</param>
        /// <returns></returns>
        public static RectTransform CreateMouseDragRect(Vector2 startPosition, Vector2 mousePosition , RectTransform rectTransform)
        {
            float areaWidth = mousePosition.x - startPosition.x;
            float areaHeight = mousePosition.y - startPosition.y;

            RectTransform unitSelectionArea = null;
        
            rectTransform.sizeDelta = new Vector2(Mathf.Abs(areaWidth), Mathf.Abs(areaHeight));
            rectTransform.anchoredPosition = startPosition + new Vector2(areaWidth / 2, areaHeight / 2);
            return rectTransform;
        }
    }
}