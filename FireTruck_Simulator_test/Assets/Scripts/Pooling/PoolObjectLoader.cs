using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public enum PoolObjectType
    {
    Road,Trees,Fuel,Fire
    }
    public class PoolObjectLoader : MonoBehaviour
    {
        public static PoolObject InstantPoolObj(PoolObjectType objectType)
        {
            GameObject Obj = null;
            switch (objectType)
            {
                case PoolObjectType.Road:
                    Obj = Instantiate(Resources.Load("Road_fab", typeof(GameObject)) as GameObject);
                    break;
                case PoolObjectType.Trees:
                    Obj = Instantiate(Resources.Load("Trees_fab", typeof(GameObject)) as GameObject);
                    break;
                case PoolObjectType.Fuel:
                    Obj = Instantiate(Resources.Load("Fuel_fab", typeof(GameObject)) as GameObject);
                    break;
                case PoolObjectType.Fire:
                    Obj = Instantiate(Resources.Load("Fire_fab", typeof(GameObject)) as GameObject);
                    break;
            }
            return Obj.GetComponent<PoolObject>();
        }
    }
}