using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbTrigger : MonoBehaviour
{
    bool p1In = false;
    bool p2In = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1In)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position += new Vector3(0f,4f * Time.deltaTime,0f);
            }
        }
        else if (p2In)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.position += new Vector3(0f, 4f * Time.deltaTime, 0f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule"))
        {
            p1In = true;
            player = other.gameObject.transform.parent.gameObject;
        }
        else if (other.gameObject.name.Equals("P2Capsule"))
        {
            p2In = true;
            player = other.gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            p1In = false;
            p2In = false;
            player = null;
        }
    }
}
