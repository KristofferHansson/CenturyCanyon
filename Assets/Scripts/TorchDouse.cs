using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDouse : MonoBehaviour
{
    [SerializeField] private Light l;
    [SerializeField] private ParticleSystem p;

    void OnTriggerEnter(Collider other)
    {
        l.intensity = 0;
        p.Stop();
    }
}
