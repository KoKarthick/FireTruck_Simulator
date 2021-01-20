using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim {
    public class LevelManager :Singleton<LevelManager>
    { 
        public void SpawnFuel(Vector3 Pos)
        {
            GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.Fuel);
            obj.transform.position = Pos;
            obj.SetActive(true);
        }
    }
}