using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim {
    public class LevelManager :Singleton<LevelManager>
    {
        private void Start()
        {
            SpawnFuel(new Vector3(0, 0, 20f));
        }

        private static void SpawnFuel(Vector3 Pos)
        {
            GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.Fuel);
            obj.transform.position = Pos;
            obj.SetActive(true);
        }
    }
}