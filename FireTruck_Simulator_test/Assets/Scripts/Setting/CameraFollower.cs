using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class CameraFollower : MonoBehaviour
    {
        Truck truck;
        Vector3 offset;
        Vector3 velocity;
        Vector3 targetPosition;
        [SerializeField] float smoothTime;
        private void Awake()
        {
            truck = FindObjectOfType<Truck>().GetComponent<Truck>();
        }
        void Start()
        {
            offset = this.transform.position - truck.transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
           targetPosition = truck.transform.position + offset;
            this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}