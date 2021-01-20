using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FireTruck_Sim
{
    public class WayPoints : MonoBehaviour
    {
        NavMeshAgent navMeshAgent;
        [SerializeField] GameObject[] _waypoints = null;
        Truck truck;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            truck = FindObjectOfType<Truck>().GetComponent<Truck>();

        }
        private void Start()
        {
            navMeshAgent.SetDestination(GetRandomPth());
        }
        private void Update()
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                navMeshAgent.SetDestination(GetRandomPth());
            }
        }
        Vector3 GetRandomPth()
        {
            int ran = Random.Range(0, _waypoints.Length);
            return _waypoints[ran].transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject==truck.gameObject)
            {
                Destroy(this.gameObject);
                truck.Speed += 0.5f;
            }
        }
    }
}