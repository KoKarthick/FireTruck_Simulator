using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class Truck : MonoBehaviour
    {
        [SerializeField] float speed;

        void Update()
        {
            this.transform.Translate(this.transform.forward * speed * Time.deltaTime);
        }
    }
}
