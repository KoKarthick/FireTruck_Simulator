using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class OnFireTriggers : MonoBehaviour
    {
        PoolObject poolObject;
        private void Start()
        {
            poolObject = GetComponent<PoolObject>();
            UIManager.Instance.FireRemain++;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Particles_trigger>()||other.GetComponent<Truck>())
            {
                UIManager.Instance.AnimalsSaved++;
                UIManager.Instance.FireRemain--;
                if (UIManager.Instance.FireRemain<1)
                {
                    UIManager.Instance.GameWon();
                }
                poolObject.TurnOff();
            }
        }
    }
}