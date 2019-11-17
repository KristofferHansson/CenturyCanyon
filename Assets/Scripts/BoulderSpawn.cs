using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawn : MonoBehaviour
{

    private Vector3 Startpos;
    //private GameObject water;

    private Rigidbody boulder;
    public GameObject nextBoulder;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Startpos = this.gameObject.transform.position;
        //water = GameObject.Find("WaterKill");
    }
        
        
    void OnTriggerEnter(Collider col)
    {
 
        if (col.tag == "Water")
        {
            Instantiate(nextBoulder, Startpos, new Quaternion(0, 0, 0, 0));
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
