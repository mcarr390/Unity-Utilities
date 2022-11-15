using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_Utilities.Extensions
{
    public static class TransformExtensions 
    {
        public static List<Transform> GetChildren(this Transform parent)
        {
            List<Transform> children = new List<Transform>();
            for (int i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i));
            }

            return children;
        }
        public static List<GameObject> GetChildrenAsGameObjects(this Transform parent)
        {
            List<GameObject> children = new List<GameObject>();
            for (int i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i).gameObject);
            }

            return children;
        }

        public static List<Transform> GetAllChildrenRecursive(this Transform parent)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parent)
            {
                Debug.Log($"Getting children of  {parent}, it has {parent.childCount}");
                children.Add(child);
            
                GetAllChildrenRecursive(child);
            }

            return children;
        }
        static List<Transform> InternalGetAllChildrenRecursive(this Transform parent)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parent)
            {
                Debug.Log($"Getting children of  {parent}, it has {parent.childCount}");
                children.Add(child);
            
                InternalGetAllChildrenRecursive(child);
            }

            return children;
        }
    
        public static Transform GetClosest(this Transform source, List<Transform> transforms)
        {
            var closest = transforms.OrderBy(go => (source.transform.position - go.transform.position).sqrMagnitude).First().transform;
            return closest;
        }
    
    }
}
