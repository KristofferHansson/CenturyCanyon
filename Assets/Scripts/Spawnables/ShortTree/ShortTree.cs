using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTree : MonoBehaviour, ISpawnable
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

    public void Spawn(Vector3 positionInPast, Vector3 offset)
    {
        past.SetActive(true);
        future.SetActive(true);
        past.transform.position = positionInPast;
        future.transform.position = positionInPast + offset;
    }
}
