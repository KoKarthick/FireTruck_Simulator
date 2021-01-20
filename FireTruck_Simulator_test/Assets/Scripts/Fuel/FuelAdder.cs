using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class FuelAdder : MonoBehaviour
    {
        PoolObject poolObject;
        private void Start()
        {
            poolObject = GetComponent<PoolObject>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Truck>())
            {
                UIManager.Instance.TruckFuel += 50;
                if (UIManager.Instance.TruckFuel>100)
                {
                    UIManager.Instance.TruckFuel = 100;
                }
                poolObject.TurnOff();
            }
        }
    }
}