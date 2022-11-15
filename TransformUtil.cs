using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_Utilities
{
    public static class TransformUtil 
    {
        // public static void GetChildRecursive(Transform obj){
        //     if (null == obj)
        //         return;
        //
        //     foreach (Transform child in obj.transform){
        //         if (null == child)
        //             continue;
        //         //child.gameobject contains the current child you can do whatever you want like add it to an array
        //         listOfChildren.Add(child);
        //         GetChildRecursive(child);
        //     }
        // }


        public static Transform GetClosestTransform(List<Transform> transforms, Transform source)
        {
            var closest = transforms.OrderBy(go => (source.transform.position - go.transform.position).sqrMagnitude).First().transform;
            return closest;
        }
    }
}
