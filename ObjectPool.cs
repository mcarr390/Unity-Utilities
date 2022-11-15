using System.Collections.Generic;
using UnityEngine;

namespace Fox.Utilities
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

    
    
        [SerializeField] List<GameObject> objectsToPool;
        Dictionary<GameObject, List<GameObject>> pooledObjects = new Dictionary<GameObject, List<GameObject>>();
        public int copiesToCreate;
    
        

        void Awake()
        {
            Instance = this;

            for (int i = 0; i < objectsToPool.Count; i++)
            {
                var listObs = new List<GameObject>();

                for (int j = 0; j < copiesToCreate; j++)
                {
                    var tmp = Instantiate(objectsToPool[i], transform);
                    tmp.SetActive(false);
                    if (!pooledObjects.ContainsKey(objectsToPool[i]))
                    {
                        pooledObjects.Add(objectsToPool[i], listObs);
                    }
                
                    pooledObjects[objectsToPool[i]].Add(tmp);

                
                }
            }
        }

        
        public GameObject GetPooledObject(GameObject prefab)
        {
            bool obIsPooled = pooledObjects.TryGetValue(prefab, out var listOfPooledObs);
            if (obIsPooled)
            {
                // try to get a pooled ob
                for (int i = 0; i < listOfPooledObs.Count; i++)
                {
                    if (!listOfPooledObs[i].activeInHierarchy)
                    {
                
                        return listOfPooledObs[i];
                    }
                }
            }
        

            return null;
        }
    }
}
