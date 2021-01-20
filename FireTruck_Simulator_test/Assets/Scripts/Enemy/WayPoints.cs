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

        IEnumerator FireUpdateRoutine;
        bool isStopped;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            truck = FindObjectOfType<Truck>().GetComponent<Truck>();

        }
        private void Start()
        {
            navMeshAgent.SetDestination(GetRandomPth());
            StartFuelUpdateRoutine();
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
                isStopped = true;
                UIManager.Instance.EnemyCarRemaining--;
                Vector3 temppos = this.transform.position;
                Vector3 pos = new Vector3(temppos.x + Random.Range(-4, 4), 0, temppos.z + Random.Range(-4, 4));
                LevelManager.Instance.SpawnFuel(pos);
                truck.Speed += 0.5f;
                Destroy(this.gameObject);
            }
        }

        void StartFuelUpdateRoutine()
        {
            if (FireUpdateRoutine != null)
            {
                StopCoroutine(FireUpdateRoutine);
            }
            FireUpdateRoutine = FuelUpdaterRoutine();
            StartCoroutine(FireUpdateRoutine);
        }
        IEnumerator FuelUpdaterRoutine()
        {
            while (!isStopped)
            {
                SpawnFuel();
                yield return new WaitForSeconds(5f);
            }
        }
        private void SpawnFuel()
        {
            GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.Fire);
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
        }
    }
}