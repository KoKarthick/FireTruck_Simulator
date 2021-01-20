using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class Singleton<T>:MonoBehaviour where T : MonoBehaviour
    {
        static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    _instance = (T)FindObjectOfType<T>();
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                    return _instance;
                }
            }
        }
        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}