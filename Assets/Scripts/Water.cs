using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // ILevelScript lvl;
    [SerializeField] private float riseRate = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // riseRate = lvl.riserate
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0f,riseRate*Time.deltaTime,0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule") || other.gameObject.name.Equals("P1Capsule"))
        {
            GameObject player = other.gameObject.transform.parent.gameObject;
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.SetUnderwater(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("P2Capsule") || other.gameObject.name.Equals("P1Capsule"))
        {
            GameObject player = other.gameObject.transform.parent.gameObject;
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.SetUnderwater(false);
        }
    }
}
