using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDouse : MonoBehaviour
{
    [SerializeField] private Light l;
    [SerializeField] private ParticleSystem p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("dousing torch");
        l.intensity = 0;
        p.Stop();
    }
}
