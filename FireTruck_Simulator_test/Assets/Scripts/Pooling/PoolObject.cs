using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FireTruck_Sim
{
    public class PoolObject : MonoBehaviour
    {
        public PoolObjectType poolObjectType;

        public void TurnOff()
        {
            this.transform.parent = null;
            this.transform.position = Vector3.zero;
            this.transform.rotation = Quaternion.identity;
            PoolManager.Instance.AddObject(this);
        }

    }
}
