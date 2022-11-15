using UnityEngine;

namespace Unity_Utilities
{
    public class MonoSingleton<T> : MonoBehaviour
        where T : Component

    {
        static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs.Length > 0)
                        _instance = objs[0];
                    if (objs.Length > 1)
                    {
                        Debug.LogError($"There is more than one {typeof(T).Name} in the scene");
                    }

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.DontSave;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}