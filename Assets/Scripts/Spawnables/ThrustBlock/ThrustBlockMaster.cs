using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustBlockMaster : MonoBehaviour, ISpawnable
{
    [SerializeField] private GameObject past;
    [SerializeField] private GameObject future;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Vector3 positionInFuture, Vector3 offset)
    {
        future.SetActive(true);
        past.SetActive(true);
        future.transform.position = positionInFuture;
        past.transform.position = positionInFuture + offset;
        future.GetComponent<ParticleSystem>().Play();
    }
}
