using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{

    private Vector3 Startpos;
    public GameObject water;

    private Rigidbody boulder;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Startpos = this.gameObject.transform.position;
    }
        
        
    void OnTriggerEnter(Collider col)
    {
 
        if (water.gameObject == col.gameObject)
        {
            transform.position = Startpos;
            boulder.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
