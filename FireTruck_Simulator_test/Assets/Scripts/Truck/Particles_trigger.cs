using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim {
    public class Particles_trigger : MonoBehaviour
    {
        ParticleSystem ps;
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // Use this for initialization
        void Start()
        {
            ps = GetComponentInChildren<ParticleSystem>();
        }


    }
}
