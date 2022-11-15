using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fox.Utilities.Extensions
{
    public static class GameObjectExtensions 
    {
        public static GameObject GetClosest(this List<GameObject> others, GameObject source)
        {
            var closest = others.OrderBy(go => (source.transform.position - go.transform.position).sqrMagnitude).First().gameObject;
            return closest;
        }
    }
}
